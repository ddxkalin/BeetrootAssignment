using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kalin.Udp.Concrete;
using Kalin.EntityframeworkCore;
using Kalin.Utility.Model;

namespace Kalin.Udp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();

            services.Configure<UdpServerOptions>(configuration.GetSection("UdpServer"));
            services.AddTransient<UdpListener>();
            services.AddTransient<KalinUdpServer>();
            services.AddInfrastructure(configuration);

            using var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<UdpListener>()?.Run(args);
        }

    }
}
