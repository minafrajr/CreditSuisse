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
                TradeService tradeService = new TradeService();
                ConfigService config = new ConfigService();

                var inputFile = config.GetConfiguration<string>(Consts.inputFilePath);
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
