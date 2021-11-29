using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditSuisse.Const;
using CreditSuisse.Interfaces;

namespace CreditSuisse.Services
{
    public class OutputLog : IOutputLog
    {
        public void WriteOutputLog(string message)
        {
            IConfigServices config;
            try
            {
                if (string.IsNullOrWhiteSpace(message))
                    throw new ArgumentNullException();

                config = new ConfigService();

                var outputFilePath = config.GetConfiguration<string>(Consts.outputFilePath);
                
                var fs = new FileStream(outputFilePath, FileMode.Append);
                using (var escritor = new StreamWriter(fs))
                {
                    escritor.WriteLine($"{message}");
                }
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
