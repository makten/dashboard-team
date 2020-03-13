using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCMS.Infrastructure.MessageQueue;
using CCMS.Infrastructure.MessageQueue.Interfaces;
using Dashboard.HDNManagementAPI.Command;
using Dashboard.HDNManagementAPI.DataAccess;
using Dashboard.HDNManagementAPI.Events;
using Dashboard.HDNManagementAPI.Model;
using Dashboard.HDNManagementAPI.Repository;
using Dashboard.MemberManagementAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Dashboard.HDNManagementAPI
{
    public class Startup
    {

     private IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // DBContext classes
        var sqlConnectionString = _configuration.GetConnectionString("HDNManagementCN");
        services.AddDbContext<HDNManagementDbContext>(opt => opt.UseSqlServer(sqlConnectionString));

        services.AddMvc(option => { option.EnableEndpointRouting = false; });

        // Message publisher classes
        var configSection = _configuration.GetSection("RabbitMQ");
        string host = configSection["Host"];
        string userName = configSection["UserName"];
        string password = configSection["Password"];

        services.AddTransient<IMessagePublisher>(
             (sp) => new QueueMessagePublisher(host, userName, password, "Dashboard"));

        services.AddTransient<IHDNRepository, HDNRepository>();

        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

        services.AddSwaggerGen(sg =>
        {
            sg.SwaggerDoc("v1", new OpenApiInfo { Title = "HDNManagement API", Version = "v1" });
        });

        services.AddHealthChecks(hc =>
        {
            hc.WithDefaultCacheDuration(TimeSpan.FromSeconds(1));
            hc.AddSqlCheck("HDNManagementCN", _configuration.GetConnectionString("HDNManagementCN"));
        });

        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostEnvironment env, IHostApplicationLifetime lifetime, HDNManagementDbContext dbContext)
    {
        Log.Logger = new LoggerConfiguration()
             .ReadFrom.Configuration(_configuration)
             .Enrich.WithMachineName()
             .CreateLogger();

        app.UseMvc();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        SetupAutoMapper();

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(su => { su.SwaggerEndpoint("/swagger/v1/swagger.json", "HDNManagement API - v1"); });

        // auto migrate the database
        using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            scope.ServiceProvider.GetService<HDNManagementDbContext>().MigrateDB();
        }
    }

    private void SetupAutoMapper()
    {
        AutoMapper.Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<RegisterHDN, HDN>();
            cfg.CreateMap<HDN, RegisterHDN>()
                .ForCtorParam("messageId", opt => opt.MapFrom(p => Guid.NewGuid()));
            cfg.CreateMap<RegisterHDN, HDNRegistered>()
                .ForCtorParam("messageId", opt => opt.MapFrom(p => Guid.NewGuid()));
        });
    }
}
}
