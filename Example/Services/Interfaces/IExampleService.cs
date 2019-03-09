namespace Example.Services.Interfaces
{
    /// <summary>
    ///     An example service with a dependency on a repository service.
    /// </summary>
    public interface IExampleService
    {
        /// <summary>
        ///     Get the name of the repository type that was created by the factory.
        /// </summary>
        /// <returns></returns>
        string GetRepositoryName();
    }
}
