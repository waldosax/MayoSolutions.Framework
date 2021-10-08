using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MayoSolutions.Framework.Configuration
{
    /// <summary>
    /// Base class for JSON file-based configuration.
    /// </summary>
    [JsonDictionary]
    public abstract class JsonFileConfigurationValuesBase : Dictionary<string, string>, IConfigurationValues
    {
        protected JsonFileConfigurationValuesBase() 
            : base(StringComparer.OrdinalIgnoreCase)
        { }

        public string GetConfigValue(string key)
        {
            return base[key];
        }

        

        protected void LoadInternal(string fileName)
        {
            Clear();
            if (!File.Exists(fileName)) return;
            
            string json = File.ReadAllText(fileName);
            var loaded = JsonConvert.DeserializeObject<JsonFileConfigurationValuesBase>(json);
            foreach (var kvp in loaded)
            {
                Add(kvp.Key, kvp.Value);
            }
        }

        protected void SaveInternal(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Directory.Exists) fi.Directory.Create();
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}