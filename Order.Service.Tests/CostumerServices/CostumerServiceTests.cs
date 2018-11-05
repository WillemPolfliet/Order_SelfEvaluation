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
                    new Costumer("Willem", "Polfliet",  "Willem@polfliet.com",  "159159159","Azerty123", new Adderss("hier","8","btown","3350")),
                    new Costumer("Melliw", "Teilflop",  "Melliw@Teilflop.com",  "951951951","Azerty123",new Adderss("hier","8","btown","3350")),
                    new Costumer("Shani", "Decoster",  "Shani@Decoster.com",  "753753753","Azerty123",new Adderss("hier","8","btown","3350")),
                    new Costumer("Inahs", "Retsoced",  "Inahs@Retsoced.com", "357357357","Azerty123",new Adderss("hier","8","btown","3350")),
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
            Costumer costumer = new Costumer("test", "test", "test@test.test", "test", "Azerty123", new Adderss("hier", "8", "btown", "3350"));

            costumerService.Register(costumer);
            var check = CustomerDatabase.CostumerDB.Any(DBCostumer => DBCostumer.Email == costumer.Email);

            Assert.True(check);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithInvalidEmail_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "test", "test", "test", "Azerty123", new Adderss("hier", "8", "btown", "3350")));

            Assert.Equal("Invalid Email", costumer.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithDuplicateEmail_ExceptionIsThrown()
        {
            Costumer costumer = new Costumer("test", "test", "Willem@polfliet.com", "test", "Azerty123", new Adderss("hier", "8", "btown", "3350"));

            var exception = Assert.Throws<CostumerException>(() => costumerService.Register(costumer));
            Assert.Equal("The costumer Email is already used. no duplicated is possible", exception.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithAnEmptyField_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "", "test@test.test", "test", "Azerty123", new Adderss("hier", "8", "btown", "3350")));

            Assert.Equal("Some fields are missing", costumer.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithAnEmptyFieldInAddress_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "test", "test@test.test", "test", "Azerty123", new Adderss("hier", "", "btown", "3350")));

            Assert.Equal("Some fields are missing", costumer.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithInvalidPassword1_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "test", "test@test.test", "test", "Azertyofzoooo", new Adderss("hier", "ofzo", "btown", "3350")));

            Assert.Equal("The password is not valid. It should contain at least one uppercase character, one lowercase character and one digit", costumer.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithInvalidPassword2_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "test", "test@test.test", "test", " ", new Adderss("hier", "ofzo", "btown", "3350")));

            Assert.Equal("Password is required", costumer.Message);
        }
        [Fact]
        public void givenAListOfCostumers_WhenRegisterANewCostumerWithInvalidPassword3_ExceptionIsThrown()
        {
            var costumer = Assert.Throws<CostumerException>(() => new Costumer("test", "test", "test@test.test", "test", "AZ", new Adderss("hier", "ofzo", "btown", "3350")));

            Assert.Equal("Password must contain at least 8 characters", costumer.Message);
        }


    }
}
