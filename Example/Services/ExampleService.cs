using System;
using Example.Services.Interfaces;

namespace Example.Services
{
    /// <inheritdoc />
    public class ExampleService : IExampleService
    {
        /// <summary>
        ///     Stores the example repository instance.
        /// </summary>
        private readonly IExampleRepository _repository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExampleService"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public ExampleService(IExampleRepository repository)
        {
            // the repository instance created by the factory
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <inheritdoc />
        public string GetRepositoryName()
        {
            return _repository.Name;
        }
    }
}
