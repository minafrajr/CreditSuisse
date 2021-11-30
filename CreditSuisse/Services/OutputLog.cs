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
        public void WriteOutputLog(List<string> outputMessage)
        {
            try
            {
                if (outputMessage.Count<1)
                    throw new ArgumentNullException();

                IConfigServices config = new ConfigService();

                var outputFilePath = config.GetConfiguration<string>(Consts.outputFilePath);
                
                var fs = new FileStream(outputFilePath, FileMode.Create);
                using (var escritor = new StreamWriter(fs))
                {
                    foreach (string message in outputMessage)
                    {
                        escritor.WriteLine($"{message}");
                    }
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
