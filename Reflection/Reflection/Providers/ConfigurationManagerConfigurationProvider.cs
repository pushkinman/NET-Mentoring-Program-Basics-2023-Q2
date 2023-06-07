using Reflection.Interfaces;
using System.Configuration;

namespace Reflection.Providers
{
    public class ConfigurationManagerConfigurationProvider : IConfigurationProvider
    {
        public object GetValue(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }

        public void SetValue(string settingName, object value)
        {
            ConfigurationManager.AppSettings[settingName] = value.ToString();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
