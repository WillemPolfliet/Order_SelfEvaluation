using Order.Database;
using Order.Domain.Costumers;
using Order.Domain.Costumers.Exceptions;
using Order.Services.CostumerServices;
using Order.Services.CostumerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Order.Services.Tests.CostumerServices
{
    public class CostumerServiceTests
    {
        ICostumerService costumerService;

        public CostumerServiceTests()
        {
            CustomerDatabase.CostumerDB.Clear();
            var temp = new List<Costumer>()
                {
                    new Costumer("Willem", "Polfliet",  "Willem@polfliet.com", "Hierzo", "159159159"),
                    new Costumer("Melliw", "Teilflop",  "Melliw@Teilflop.com", "Ozreih", "951951951"),
                    new Costumer("Shani", "Decoster",  "Shani@Decoster.com", "Daarzo", "753753753"),
                    new Costumer("Inahs", "Retsoced",  "Inahs@Retsoced.com", "Ozraad", "357357357"),
                };
            CustomerDatabase.CostumerDB.AddRange(temp);

            costumerService = new CostumerService();
        }

        [Fact]
        public void givenAListOfCostumers_Happy_WhenGetAllCostumers_AListOfAllCostumersIsReturned()
        {
            var actual = costumerService.GetAllCostumers();

            Assert.Equal(CustomerDatabase.CostumerDB.Count, actual.Count);
        }

        [Fact]
        public void givenAListOfCostumers_Happy_WhenRegisterANewCostumer_TheNewCostumerISAddedToTheDB()
        {
            Costumer costumer = new Costumer("test", "test", "test@test.test", "test", "test");

            costumerService.Register(costumer);
            var check = CustomerDatabase.CostumerDB.Any(DBCostumer => DBCostumer.Email == costumer.Email);

            Assert.True(check);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithInvalidEmail_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "test", "test", "test", "test"));

            Assert.Equal("Invalid Email", costumer.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithDuplicateEmail_ExceptionIsThrown()
        {
            Costumer costumer = new Costumer("test", "test", "Willem@polfliet.com", "test", "test");

            var exception = Assert.Throws<CostumerException>(() => costumerService.Register(costumer));
            Assert.Equal("The costumer Email is already used. no duplicated is possible", exception.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithAnEmptyField_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "", "test@test.test", "test", "test"));

            Assert.Equal("Some fields are missing", costumer.Message);
        }


    }
}
