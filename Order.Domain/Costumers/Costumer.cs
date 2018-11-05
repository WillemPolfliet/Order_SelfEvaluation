using Order.Domain.Costumers.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Order.Domain.Costumers
{
    public class Costumer
    {
        private const int REQUIRED_PASSWORD_LENGTH = 8;

        public Guid Id { get; }
        public string Firstname { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Adderss Address { get; private set; }
        public string Phonenumber { get; private set; }
        public string Password { get; private set; }

        public Costumer(string firstname, string lastName, string email, string phonenumber, string password, Adderss address)
        {
            CheckValidInput(password, firstname, lastName, email, address, phonenumber);

            Id = Guid.NewGuid();
            Firstname = firstname;
            LastName = lastName;
            Email = CheckEmail(email);
            Address = address;
            Phonenumber = phonenumber;
            Password = CheckPassword(password);
        }

        private void CheckValidInput(string password, string firstname, string lastName, string email, Adderss address, string phonenumber)
        {
            if (password == string.Empty || email == string.Empty || firstname == string.Empty || lastName == string.Empty || phonenumber == string.Empty ||
                address.StreetNumber == string.Empty || address.PostalArea == string.Empty || address.PostalNumber == string.Empty || address.StreetName == string.Empty)
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
        private string CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new CostumerException("Password is required");
            }
            if (password.Length < REQUIRED_PASSWORD_LENGTH)
            {
                throw new CostumerException($"Password must contain at least {REQUIRED_PASSWORD_LENGTH} characters");
            }
            if (!Regex.Match(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]").Success)
            {
                throw new CostumerException("The password is not valid. It should contain at least one uppercase character, one lowercase character and one digit");
            }
            return password;
        }
    }
}
