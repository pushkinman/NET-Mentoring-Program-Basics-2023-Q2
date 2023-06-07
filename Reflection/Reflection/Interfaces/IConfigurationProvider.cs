using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Interfaces
{
    interface IConfigurationProvider
    {
        object GetValue(string settingName);
        void SetValue(string settingName, object value);
    }
}
