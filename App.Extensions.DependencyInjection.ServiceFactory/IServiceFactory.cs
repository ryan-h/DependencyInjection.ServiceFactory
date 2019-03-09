using System;

namespace App.Extensions.DependencyInjection.ServiceFactory
{
    /// <summary>
    ///      A factory for creating service instances of a specified implementation type.
    /// </summary>
    /// <typeparam name="T">The service type.</typeparam>
    public interface IServiceFactory<out T> where T : class
    {
        /// <summary>
        ///     Create an instance of the service implementation.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The service instance.</returns>
        T Create(IServiceProvider serviceProvider);
    }
}
