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

                Console.WriteLine("**************** WELCOME TO CREDIT SUISSE TRADE CATEGORIZATION PROGRAM **********************");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Press ENTER button to start...");
                Console.ReadLine();

                Console.WriteLine("Collecting configurations...");
                var inputFile = config.GetConfiguration<string>(Consts.inputFilePath);

                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();

                Console.WriteLine("Acquiring portfolio and categorizing trades...");
                var categoriesList = tradeService.Categorize(inputFile);
                
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();

                Console.WriteLine("Writing output file..");
                outputLog.WriteOutputLog(categoriesList);


                Console.WriteLine("Process finished!");

                Console.ReadLine();
                Console.WriteLine("Press ENTER button to close...");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
