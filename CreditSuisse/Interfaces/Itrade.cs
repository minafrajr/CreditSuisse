using System;

namespace CreditSuisse.Interfaces
{
    public interface ITrade
    {
        DateTime ReferenceDate { get;  } //the reference date
        int NTrades { get; } //number of trades in the portfolio
        double Value { get; } //indicates the transaction amount in dollars
        string ClientSector { get; } //indicates the client´s sector which can be "Public" or "Private"
        DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected
    }
}
