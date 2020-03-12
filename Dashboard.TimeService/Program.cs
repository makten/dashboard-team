using System.IO;
using System.Threading.Tasks;
using CCMS.Infrastructure.MessageQueue;
using CCMS.Infrastructure.MessageQueue.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Dashboard.TimeService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var host = createHostBuilder(args).Build();
            await host.RunAsync();
        }

        private static IHostBuilder createHostBuilder(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureHostConfiguration(config =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("hostsettings.json", optional: true);
                    config.AddJsonFile($"appsettings.json", optional: true);
                    config.AddEnvironmentVariables();
                    config.AddEnvironmentVariables("DOTNET_");
                    config.AddCommandLine(args);
                })
                .ConfigureAppConfiguration((hostContext, conf) =>
                {
                    conf.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                        optional: false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IMessagePublisher>((svc) =>
                    {
                        var rabbitMQConfigSection = hostContext.Configuration.GetSection("RabbitMQ");
                        string rabbitMQHost = rabbitMQConfigSection["Host"];
                        string rabbitMQUserName = rabbitMQConfigSection["UserName"];
                        string rabbitMQPassword = rabbitMQConfigSection["Password"];
                        return new QueueMessagePublisher(rabbitMQHost, rabbitMQUserName, rabbitMQPassword, "Dashboard");
                    });

                    services.AddHostedService<TimeManager>();
                })
                .UseSerilog((hostContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration);
                })
                .UseConsoleLifetime();

            return hostBuilder;
        }
    }
}
