using Reflection.Attributes;
using Reflection.Interfaces;
using System;
using System.Reflection;

namespace Reflection.Configuration
{
    public class ConfigurationComponentBase
    {
        public void SaveSettings()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<ConfigurationItemAttribute>();
                if (attribute != null)
                {
                    var provider = Activator.CreateInstance(attribute.ProviderType) as IConfigurationProvider;
                    var value = property.GetValue(this);
                    provider.SetValue(attribute.SettingName, value);
                }
            }
        }

        public void LoadSettings()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<ConfigurationItemAttribute>();
                if (attribute != null)
                {
                    var provider = Activator.CreateInstance(attribute.ProviderType) as IConfigurationProvider;
                    var value = provider.GetValue(attribute.SettingName);
                    if (value != null)
                        property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
                }
            }
        }
    }
}
