namespace MayoSolutions.Framework.Configuration
{
    /// <summary>
    /// Interface for supporting file-based configuration.
    /// Allows for specifying a file path for serialization/deserialization.
    /// </summary>
    public interface IFileConfigurationValues : IConfigurationValues
    {
        void LoadFromFile(string fileName);
        void SaveToFile(string fileName);
    }
}