using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.OrderGroups.Exceptions
{
    class OrderItemException : Exception
    {
        public OrderItemException(string message) : base(message)
        {
        }
    }
}