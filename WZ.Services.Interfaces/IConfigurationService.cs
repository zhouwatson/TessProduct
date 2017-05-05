using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Services.Interfaces
{
    public interface IConfigurationService
    {
        /// <summary>
        /// Get Config Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T GetValue<T>(string keyName, T defaultValue);

        /// <summary>
        /// Get List Config Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        List<T> GetList<T>(string keyName, string defaultValue);

    }
}
