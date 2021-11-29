using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditSuisse.Interfaces;

namespace CreditSuisse
{
    public class Trade :ITrade
    {
        public DateTime ReferenceDate { get; set; }
        public int NTrades { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
    }
}
