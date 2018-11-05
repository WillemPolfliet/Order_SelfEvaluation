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
            CheckValidInput(firstname, lastName, email, address, phonenumber);

            Id = Guid.NewGuid();
            Firstname = firstname;
            LastName = lastName;
            Email = CheckEmail(email);
            Address = address;
            Phonenumber = phonenumber;
        }

        private void CheckValidInput(string firstname, string lastName, string email, string address, string phonenumber)
        {
            if (email == string.Empty || firstname == string.Empty || lastName == string.Empty || address == string.Empty || phonenumber == string.Empty)
            {
                throw new CostumerException("Some fields are missing");
            }
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
