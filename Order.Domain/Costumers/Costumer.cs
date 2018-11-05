using Order.Domain.Costumers.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Order.Domain.Costumers
{
    public class Costumer
    {
        public Guid Id { get; }
        public string Firstname { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Phonenumber { get; private set; }

        public Costumer(string firstname, string lastName, string email, string address, string phonenumber)
        {
            Id = Guid.NewGuid();
            Firstname = firstname;
            LastName = lastName;
            Email = CheckEmail(email);
            Address = address;
            Phonenumber = phonenumber;
        }

        private string CheckEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return email;
            }
            catch (FormatException)
            {
                throw new CostumerException("Invalid Email");
            }
        }
    }
}
