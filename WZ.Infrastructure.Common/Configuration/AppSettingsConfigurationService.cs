using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Infrastructure.Common.Configuration
{
    public class AppSettingsConfigurationService : Services.Interfaces.IConfigurationService
    {
        /// <summary>
        /// config separator for list values, default use ,
        /// </summary>
        public string ConfigSeparator
        {
            get
            {
                return GetValue("CONFIG_SEPARATOR", ",");
            }
        }

        /// <summary>
        /// Get config value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValue<T>(string keyName, T defaultValue)
        {
            var configValue = ConfigurationManager.AppSettings[keyName];
            if (configValue == null)
                return defaultValue;

            T parseResult;
            if (TryParse(configValue, out parseResult))
            {
                return parseResult;
            }
            return defaultValue;
        }

        /// <summary>
        /// Get List Config Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string keyName, string defaultValue)
        {
            var configValue = GetValue(keyName, defaultValue);

            return ParseToList<T>(configValue, ConfigSeparator);
        }

        /// <summary>
        /// parse string to a list by separator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configValue"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public List<T> ParseToList<T>(string configValue, string separator)
        {
            List<T> returnList = new List<T>();

            if (string.IsNullOrWhiteSpace(configValue))
                return returnList;

            var valueList = configValue.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in valueList)
            {
                T parseResult;
                if (TryParse(value, out parseResult))
                {
                    returnList.Add(parseResult);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("'{0}' is not type of '{1}' from: '{2}'", value, typeof(T), configValue));
                }
            }
            return returnList;
        }

        /// <summary>
        /// General convert object type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool TryParse<T>(string input, out T result)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            if (converter != null && converter.IsValid(input))
            {
                result = (T)converter.ConvertFromString(input);
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }
    }
}
