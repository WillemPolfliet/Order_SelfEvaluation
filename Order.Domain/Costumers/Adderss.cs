using Order.Domain.Costumers.Exceptions;
using System;

namespace Order.Domain.Costumers
{
    public class Adderss
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalArea { get; set; }
        public string PostalNumber { get; set; }

        public Adderss(string street, string number, string postalArea, string postalNumber)
        {
            StreetName = street;
            StreetNumber = number;
            PostalArea = postalArea;
            PostalNumber = postalNumber;
        }
    }
}