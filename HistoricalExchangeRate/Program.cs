using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using StructureMap;

namespace HistoricalExchangeRate
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceProvider = ConfigureIoC(new ServiceCollection());
            serviceProvider.GetService<ConsoleApp>().Run();
        }

        public static IServiceProvider ConfigureIoC(IServiceCollection servicesCollection)
        {
            servicesCollection.AddOptions();
            //servicesCollection.Configure<ApiSettings>(options => Configuration.GetSection("ApiSettings").Bind(options));
            servicesCollection.AddTransient<ConsoleApp>();

            var container = new Container(config =>
            {
                config.Scan(x =>
                {
                    x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    x.LookForRegistries();
                    x.WithDefaultConventions();
                });

                config.Populate(servicesCollection);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
