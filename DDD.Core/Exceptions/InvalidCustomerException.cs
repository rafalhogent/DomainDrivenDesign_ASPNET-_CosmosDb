using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Core.Exceptions
{
    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException(string customerID, string? message) : base(message)
        {
            CustomerID = customerID;
        }

        public string CustomerID { get; set; } = null!;
    }
}
