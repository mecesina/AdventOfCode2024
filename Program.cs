using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AoC2024D1P1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddUserSecrets<Program>();
                })
                .ConfigureServices((context, services) =>
                {
                    // Configure PathsOptions
                    services.Configure<Paths>(context.Configuration.GetSection("Paths"));

                    // Register PathsService
                    services.AddSingleton<PathsService>();

                    // Register other dependent classes
                    services.AddTransient<Day1>();
                    services.AddTransient<Day2>();
                })
                .Build();

            var day1 = host.Services.GetRequiredService<Day1>();
            day1.HandleFlow();

            var day2 = host.Services.GetRequiredService<Day2>();
            day2.SolutionDay2();

            //host.RunAsync();
        }
    }
}
