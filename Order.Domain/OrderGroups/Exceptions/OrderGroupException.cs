using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.OrderGroups.Exceptions
{
    class OrderGroupException : Exception
    {
        public OrderGroupException(string message) : base(message)
        {
        }
    }
}