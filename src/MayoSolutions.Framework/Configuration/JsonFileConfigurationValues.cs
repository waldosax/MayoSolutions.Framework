namespace MayoSolutions.Framework.Configuration
{
    /// <summary>
    /// JSON file-based configuration.
    /// Allows for specifying a file path for serialization/deserialization.
    /// </summary>
    public class JsonFileConfigurationValues : JsonFileConfigurationValuesBase, IFileConfigurationValues
    {
        public void LoadFromFile(string fileName)
        {
            LoadInternal(fileName);
        }

        public void SaveToFile(string fileName)
        {
            SaveInternal(fileName);
        }
    }
}