using Order.Domain.Items.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Items
{
    public class Item
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; set; }

        public Item(string name, decimal price, int amount, string description)
        {
            CheckValidInput(name, price, amount, description);

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
        }

        private void CheckValidInput(string name, decimal price, int amount, string description)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            { throw new ItemException("All fields are required"); }
            if (amount < 0)
            { throw new ItemException("The amount cannot be negative"); }
            if (price < 0)
            { throw new ItemException("The price cannot be negative"); }
        }
    }
}
