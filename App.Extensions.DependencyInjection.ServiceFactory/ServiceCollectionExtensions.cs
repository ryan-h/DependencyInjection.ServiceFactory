using System;
using Microsoft.Extensions.DependencyInjection;

namespace App.Extensions.DependencyInjection.ServiceFactory
{
    /// <summary>
    ///     Extension methods for adding a service factory to an <see cref="IServiceCollection" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Add a factory for dynamically creating the service instance that will be provided.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <typeparam name="TFactory">The type of the service factory.</typeparam>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="lifetime">The lifetime for the service.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddFactory<T, TFactory>(
            this IServiceCollection serviceCollection, ServiceLifetime lifetime = ServiceLifetime.Singleton
        ) where T : class where TFactory : class, IServiceFactory<T>
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            // add the factory that will create the service
            serviceCollection.AddTransient<TFactory>();

            // add the service created by the factory
            serviceCollection.Add(new ServiceDescriptor(
                typeof(T),
                provider => provider.GetRequiredService<TFactory>().Create(provider),
                lifetime
            ));

            return serviceCollection;
        }
    }
}
