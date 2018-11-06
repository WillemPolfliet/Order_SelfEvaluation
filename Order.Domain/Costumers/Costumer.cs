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
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Adderss Address { get; private set; }
        public string Phonenumber { get; private set; }
        public string Password { get; private set; }
        public EnumRoles Role { get; set; }

        public Costumer(string firstname, string lastName, string email, string phonenumber, string password, Adderss address)
        {
            CheckValidInput(password, firstname, lastName, email, address, phonenumber);

            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastName;
            Email = CheckEmail(email);
            Address = address;
            Phonenumber = phonenumber;
            Password = CheckPassword(password);
            Role = EnumRoles.COSTUMER;
        }

        public static Costumer ChangeRoleToAdmin(Costumer costumer)
        {
            costumer.Role = EnumRoles.ADMIN;
            return costumer;
        }

        private void CheckValidInput(string password, string firstname, string lastName, string email, Adderss address, string phonenumber)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phonenumber) ||
                 string.IsNullOrEmpty(address.StreetNumber) || string.IsNullOrEmpty(address.PostalArea) || string.IsNullOrEmpty(address.PostalNumber) || string.IsNullOrEmpty(address.StreetName))
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
