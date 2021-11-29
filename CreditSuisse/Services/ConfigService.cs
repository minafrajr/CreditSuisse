using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CreditSuisse.Interfaces;

namespace CreditSuisse.Services
{
    class ConfigService:IConfigServices
    {
        public T GetConfiguration<T>(string key)
        {
            try
            {
                object value = ConfigurationManager.AppSettings[key];

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
