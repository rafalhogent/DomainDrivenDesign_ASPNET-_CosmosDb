using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Core.Exceptions
{
    public class WrongCustomerDataException : Exception
    {
        public WrongCustomerDataException(string? message) : base(message)
        {

        }
    }
}
