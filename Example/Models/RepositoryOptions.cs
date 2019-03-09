using System;

namespace Example.Models
{
    /// <summary>
    ///     The model for the repository options configuration.
    /// </summary>
    [Serializable]
    public class RepositoryOptions
    {
        /// <summary>
        ///     The type name for the repository.
        /// </summary>
        public string Type { get; set; }
    }
}
