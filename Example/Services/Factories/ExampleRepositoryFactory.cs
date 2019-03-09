using System;
using App.Extensions.DependencyInjection.ServiceFactory;
using Example.Models;
using Example.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Example.Services.Factories
{
    /// <inheritdoc />
    public class ExampleRepositoryFactory : IServiceFactory<IExampleRepository>
    {
        /// <summary>
        ///     Stores the repository options.
        /// </summary>
        private readonly RepositoryOptions _repositoryOptions;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExampleRepositoryFactory"/> class.
        /// </summary>
        /// <param name="repositoryOptionsAccessor"></param>
        public ExampleRepositoryFactory(IOptions<RepositoryOptions> repositoryOptionsAccessor)
        {
            if (repositoryOptionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(repositoryOptionsAccessor));
            }

            _repositoryOptions = repositoryOptionsAccessor.Value;
        }

        /// <inheritdoc />
        public IExampleRepository Create(IServiceProvider serviceProvider)
        {
            // get the assembly-qualified name of the repository type from configuration
            var repositoryType = Type.GetType(_repositoryOptions.Type);

            if (repositoryType == null)
            {
                throw new Exception("Unable to get the repository type.");
            }

            // find the repository service by the provided type
            var repository = serviceProvider.GetService(repositoryType);

            if (repository == null)
            {
                throw new Exception("The repository service was not found.");
            }

            return repository as IExampleRepository;
        }
    }
}
