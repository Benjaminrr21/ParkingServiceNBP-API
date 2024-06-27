using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Exceptions
{
    public class CantReserveWithouCardException : Exception
    {
        private static string errMsg = "Ne mozete rezervisati parking mesta bez posedovanja vazece karte (pretplatne ili jednokratne)!";
        public CantReserveWithouCardException() : base(errMsg) { }
        public CantReserveWithouCardException(string msg) : base(msg) { }
        public CantReserveWithouCardException(string msg, Exception innerException) : base(msg,innerException) { }

        
    }
}
