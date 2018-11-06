using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Database.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }
    }
}