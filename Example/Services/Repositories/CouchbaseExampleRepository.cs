using Example.Services.Interfaces;

namespace Example.Services.Repositories
{
    /// <summary>
    ///     A repository implementation with a Couchbase back-end.
    /// </summary>
    public class CouchbaseExampleRepository : IExampleRepository
    {
        /// <inheritdoc />
        public string Name => GetType().FullName;
    }
}
