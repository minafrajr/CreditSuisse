using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CreditSuisse.Const;
using CreditSuisse.Interfaces;

namespace CreditSuisse.Services
{
    public class TradeService
    {
        private Trade trade;
        private List<Trade> tradeList;
        private Categories categories;
        private List<string> categoryList;

        public List<string> Categorize(string inputFile)
        {
            try
            {
                categoryList = new List<string>();

                GetTrades(inputFile);

                foreach (Trade tradeItem in tradeList)
                {
                    categories = IsExpired(tradeItem) ? Categories.EXPIRED : CalculateRisk(tradeItem);

                    categoryList.Add(categories.ToString());
                }

                return categoryList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trade"></param>
        /// <returns></returns>
        private Categories CalculateRisk(Trade trade)
        {
            try
            {
                if (trade.Value > 1000000 && trade.ClientSector == "Private")
                    return Categories.HIGHRISK;

                if (trade.Value > 1000000 && trade.ClientSector == "Public")
                    return Categories.MEDIUMRISK;

                return Categories.UNDEFINED;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Calculate the diference in days between reference date and next payment date
        /// </summary>
        /// <param name="trade">The trade</param>
        /// <returns>true: the payment date is late by more than 30 days based on a reference date| false: the payment date is update based on a reference date</returns>
        private bool IsExpired(ITrade trade)
        {
            try
            {
                if (trade.ReferenceDate.Subtract(trade.NextPaymentDate).TotalDays > 30)
                    return true;

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private List<Trade> GetTrades(string inputFile)
        {
            tradeList = new List<Trade>();

            try
            {
                if (inputFile.Equals(null) || inputFile.Equals(""))
                    throw new ArgumentNullException();


                if (!inputFile.Contains("txt"))
                    throw new FileLoadException();

                if (!File.Exists(inputFile))
                    throw new FileNotFoundException();

                char[] delim = { ' ' };
                DateTime referenceDate;
                int nTrades;

                using (var text = new StreamReader(inputFile))
                {
                    while (text.Peek() >= 0)
                    {
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
                                    trade = new Trade();
                                    trade.ReferenceDate = referenceDate;
                                    trade.Value = Convert.ToDouble(arrStrings[0]);
                                    trade.ClientSector = arrStrings[1];
                                    trade.NextPaymentDate = Convert.ToDateTime(arrStrings[2], new CultureInfo("en-US"));

                                    tradeList.Add(trade);
                                }
                            }
                        }
                    }
                }

                return tradeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
