using JoySoftware.HomeAssistant.NetDaemon.DaemonRunner.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cs
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(s => { s.AddHostedService<RunnerService>(); })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole(options => options.IncludeScopes = false);
                    logging.AddDebug();
                    logging.AddFilter("Microsoft", LogLevel.Error);
                    logging.SetMinimumLevel(LogLevel.Information);
                });
    }
}
