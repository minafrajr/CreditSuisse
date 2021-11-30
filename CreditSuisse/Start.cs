using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditSuisse.Const;
using CreditSuisse.Interfaces;
using CreditSuisse.Services;

namespace CreditSuisse
{
    public  class Start
    {
        public static void Execute()
        {
            try
            {
                var tradeService = new TradeService();
                var config = new ConfigService();
                var outputLog = new OutputLog();

                var inputFile = config.GetConfiguration<string>(Consts.inputFilePath);

                var categoriesList = tradeService.Categorize(inputFile);

                outputLog.WriteOutputLog(categoriesList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
