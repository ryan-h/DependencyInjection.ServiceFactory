using Example.Services.Interfaces;

namespace Example.Services.Repositories
{
    /// <summary>
    ///     A repository implementation with a Cosmos back-end.
    /// </summary>
    public class CosmosExampleRepository : IExampleRepository
    {
        /// <inheritdoc />
        public string Name => GetType().FullName;
    }
}
