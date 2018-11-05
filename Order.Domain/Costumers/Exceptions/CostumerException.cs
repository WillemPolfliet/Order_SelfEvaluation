using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Costumers.Exceptions
{
    public class CostumerException : Exception
    {
        public CostumerException(string message) : base(message)
        {
        }
    }
}