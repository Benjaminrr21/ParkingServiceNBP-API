using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Exceptions
{
    public class EntityNullException : Exception
    {
        private static string msg = "Objekat ne postoji u bazi!";
        public EntityNullException() : base(msg) { }
        public EntityNullException(string message) : base(message) { }
        public EntityNullException(string message, Exception innerException) : base(message, innerException) { }

    }
}
