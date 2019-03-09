using System;
using Example.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var startup = new Startup();

            try
            {
                startup.ConfigureServices(services);

                var provider = services.BuildServiceProvider();
                var service = provider.GetRequiredService<IExampleService>();

                Console.WriteLine($"Implemented repository: {service.GetRepositoryName()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
