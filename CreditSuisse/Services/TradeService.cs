using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CreditSuisse.Interfaces;

namespace CreditSuisse.Services
{
    public class TradeService
    {
        private Trade trade;
        private List<Trade> tradesList;

        public string Categorize(string inputFile)
        {
            tradesList = GetTrades(inputFile);

            try
            {
                foreach (Trade tradeItem in tradesList)
                {
                    //todo analizar as trades (Expired  HighRisk MediumRisk)
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }

        private List<Trade> GetTrades(string inputFile)
        {
            var tradesList = new List<Trade>();

            try
            {
                if (inputFile.Equals(null) || inputFile.Equals(""))
                    throw new ArgumentNullException();


                if (!inputFile.Contains("txt"))
                    throw new FileLoadException();

                if (!File.Exists(inputFile))
                    throw new FileNotFoundException();
                
                char[] delim = { ' ' };
                var campoObrigatorio = true;
                DateTime referenceDate;
                int nTrades;

                using (var text = new StreamReader(inputFile))
                {
                    while (text.Peek() >= 0)
                    {
                        trade = new Trade();

                        var line = text.ReadLine(); //read each line 

                        if (line.Equals("")) line = text.ReadLine();

                        var arrStrings = line.Split(delim, StringSplitOptions.None); //gets each lines from txt file

                        if (DateTime.TryParse(arrStrings[0], out referenceDate))
                        {
                            line = text.ReadLine();
                            arrStrings = line.Split(delim, StringSplitOptions.None);

                            if (int.TryParse(arrStrings[0], out nTrades))
                            {
                                for (int i = 0; i < nTrades; i++)
                                {
                                    line = text.ReadLine();

                                    if (line.Equals("")) line = text.ReadLine();

                                    arrStrings = line.Split(delim, StringSplitOptions.None);
                                    trade.ReferenceDate = referenceDate;
                                    trade.Value = Convert.ToDouble(arrStrings[0]);
                                    trade.ClientSector = arrStrings[1];
                                    trade.NextPaymentDate = Convert.ToDateTime(arrStrings[2], new CultureInfo("en-US"));

                                    tradesList.Add(trade);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return tradesList;
        }
    }
}
