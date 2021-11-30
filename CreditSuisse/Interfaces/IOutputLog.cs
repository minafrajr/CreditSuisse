using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Interfaces
{
    public interface IOutputLog
    {
        void WriteOutputLog(List<string> outputMessage);

    }
}
