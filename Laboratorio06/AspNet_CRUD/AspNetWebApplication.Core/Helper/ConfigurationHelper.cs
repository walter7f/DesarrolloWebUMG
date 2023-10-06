using System.Configuration;

namespace AspNetWebApplication.Core.Helper
{
    public class ConfigurationHelper
    {
        public static string GetSetting(string settingKey)
        {
            return ConfigurationManager.AppSettings[settingKey];
        }

        public static bool GetBoolSetting(string settingKey)
        {
            bool value;
            bool.TryParse(GetSetting(settingKey), out value);
            return value;
        }
    }
}
