using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.PlacedOrders.Exceptions
{
    public class PlacedOrderException : Exception
    {
        public PlacedOrderException(string message) : base(message)
        {
        }
    }
}