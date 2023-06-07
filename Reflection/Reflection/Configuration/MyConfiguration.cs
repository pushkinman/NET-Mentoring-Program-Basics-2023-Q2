using Reflection.Attributes;
using Reflection.Providers;
using System;

namespace Reflection.Configuration
{
    public class MyConfiguration : ConfigurationComponentBase
    {
        [ConfigurationItem("MyIntSetting", typeof(FileConfigurationProvider))]
        public int MyIntSetting { get; set; }

        [ConfigurationItem("MyFloatSetting", typeof(ConfigurationManagerConfigurationProvider))]
        public float MyFloatSetting { get; set; }

        [ConfigurationItem("MyStringSetting", typeof(FileConfigurationProvider))]
        public string MyStringSetting { get; set; }

        [ConfigurationItem("MyTimeSpanSetting", typeof(ConfigurationManagerConfigurationProvider))]
        public TimeSpan MyTimeSpanSetting { get; set; }
    }
}
