using System;
using CCMS.Infrastructure.MessageQueue;
using CCMS.Infrastructure.MessageQueue.Interfaces;
using Dashboard.MemberManagementAPI.Command;
using Dashboard.MemberManagementAPI.DataAccess;
using Dashboard.MemberManagementAPI.Events;
using Dashboard.MemberManagementAPI.Model;
using Dashboard.MemberManagementAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Dashboard.MemberManagementAPI
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
            var sqlConnectionString = _configuration.GetConnectionString("MemberManagementCN");
            services.AddDbContext<MemberManagementDbContext>(opt => opt.UseSqlServer(sqlConnectionString));

            services.AddMvc(option => { option.EnableEndpointRouting = false; });

            // Message publisher classes
            var configSection = _configuration.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];

            services.AddTransient<IMessagePublisher>(
                 (sp) => new QueueMessagePublisher(host, userName, password, "Dashboard"));

            services.AddTransient<IMemberRepository, MemberRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(sg =>
            {
                sg.SwaggerDoc("v1", new OpenApiInfo {Title = "MemberManagement API", Version = "v1"}); });

            services.AddHealthChecks(hc =>
            {
                hc.WithDefaultCacheDuration(TimeSpan.FromSeconds(1));
                hc.AddSqlCheck("MemberManagementCN", _configuration.GetConnectionString("MemberManagementCN"));
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IHostApplicationLifetime lifetime, MemberManagementDbContext dbContext)
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
            app.UseSwaggerUI(su => { su.SwaggerEndpoint("/swagger/v1/swagger.json", "MemberManagement API - v1"); });

            // auto migrate the database
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<MemberManagementDbContext>().MigrateDB();
            }
        }

        private void SetupAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterMember, Member>();
                cfg.CreateMap<Member, RegisterMember>()
                    .ForCtorParam("messageId", opt => opt.MapFrom(p => Guid.NewGuid()));
                cfg.CreateMap<RegisterMember, MemberRegistered>()
                    .ForCtorParam("messageId", opt => opt.MapFrom(p => Guid.NewGuid()));
            });
        }
    }
}
