using System;
using System.IO;
using App.Extensions.DependencyInjection.ServiceFactory;
using Example.Models;
using Example.Services;
using Example.Services.Factories;
using Example.Services.Interfaces;
using Example.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example
{
    public class Startup
    {
        /// <summary>
        ///     The configuration for the app settings.
        /// </summary>
        public IConfigurationRoot Configuration { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", true);

            Configuration = builder.Build();
        }

        /// <summary>
        ///     Configures the application services.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            configureOptions(services);

            // add the factory which will dynamically create the repository instance based on the configured type
            services.AddFactory<IExampleRepository, ExampleRepositoryFactory>();

            // add the available repositories
            services.AddTransient<CosmosExampleRepository>();
            services.AddTransient<CouchbaseExampleRepository>();

            // add a service that consumes the repository
            services.AddSingleton<IExampleService, ExampleService>();
        }

        /// <summary>
        ///     Configures the application configuration options.
        /// </summary>
        /// <param name="services"></param>
        private void configureOptions(IServiceCollection services)
        {
            services.AddOptions();

            // add the options containing the repository type name
            services.Configure<RepositoryOptions>(Configuration.GetSection(nameof(RepositoryOptions)));
        }
    }
}
