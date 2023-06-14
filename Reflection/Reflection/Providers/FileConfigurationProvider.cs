using Newtonsoft.Json;
using Reflection.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Reflection.Providers
{
    public class FileConfigurationProvider : IConfigurationProvider
    {
        private readonly string filePath;

        public FileConfigurationProvider()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(documentsPath, "config.txt");
        }

        public object GetValue(string settingName)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                var content = reader.ReadToEnd();
                var settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                if (settings.TryGetValue(settingName, out var value))
                {
                    return value;
                }

                return null;
            }
        }

        public void SetValue(string settingName, object value)
        {
            string content;
            using (StreamReader reader = File.OpenText(filePath))
            {
                content = reader.ReadToEnd();
            }

            var settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
            settings[settingName] = value;
            using (StreamWriter writer = File.CreateText(filePath))
            { 
                writer.Write(JsonConvert.SerializeObject(settings));
            }
        }
    }
}
