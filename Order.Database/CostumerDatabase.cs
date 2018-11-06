using Order.Domain.Costumers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Database
{
    public static class CostumerDatabase
    {
        public static List<Costumer> CostumerDB = new List<Costumer>()
        {
            Costumer.ChangeRoleToAdmin(new Costumer("Admin", "lastname","admin@admin.com","1519159159","Azerty123", new Adderss("a","b","c","d"))),
            new Costumer("Default1", "lastname","Default1@abc.com","1519159159","Azerty123", new Adderss("a","b","c","d")),
            new Costumer("Default2", "lastname","Default2@abc.com","1519159159","Azerty123", new Adderss("a","b","c","d")),
            new Costumer("Default3", "lastname","Default3@abc.com","1519159159","Azerty123", new Adderss("a","b","c","d"))
        };

    }
}
