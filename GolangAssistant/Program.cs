using System;
using System.IO;
using System.Threading.Tasks;
using GolangAssistant.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace GolangAssistant
{
    class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\goasettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(Configuration)
               .Enrich.FromLogContext()
               .CreateLogger();

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddLogging(config =>
                {
                    config.ClearProviders();
                    config.AddProvider(new SerilogLoggerProvider(Log.Logger));
                    var minimumLevel = Configuration.GetSection("Serilog:MinimumLevel")?.Value;
                    if (!string.IsNullOrEmpty(minimumLevel))
                    {
                        config.SetMinimumLevel(Enum.Parse<LogLevel>(minimumLevel));
                    }
                });
            });

            try
            {
                return await builder.RunCommandLineApplicationAsync<GoaCmd>(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}
