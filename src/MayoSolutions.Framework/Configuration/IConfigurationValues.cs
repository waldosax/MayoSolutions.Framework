namespace MayoSolutions.Framework.Configuration
{
    /// <summary>
    /// Interface used for retrieving configuration values
    /// </summary>
    public interface IConfigurationValues
    {
        string GetConfigValue(string key);
    }
}
