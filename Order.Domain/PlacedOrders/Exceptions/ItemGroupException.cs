using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.PlacedOrders.Exceptions
{
    public class ItemGroupException : Exception
    {
        public ItemGroupException(string message) : base(message)
        {
        }
    }
}