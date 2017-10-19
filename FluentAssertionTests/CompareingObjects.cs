using FluentAssertions;
using Xunit;

namespace FluentAssertionTests
{
    public class CompareingObjects
    {
        [Fact]
        public void CompareTwoObjects()
        {
            var customer1 = new Customer("cust-1", "John Doe")
            {
                Address =
                {
                    City = "NY",
                    Country = "US",
                    Street = "123 fake St."
                }
            };

            var customer2 = new Customer("cust-2", "John Doe")
            {
                Address =
                {
                    City = "NY",
                    Country = "US",
                    Street = "123 another St."
                }
            };


            customer1.Should().BeEquivalentTo(customer2, o => o.Excluding(customer => customer.Id));
        }
    }

    public class Customer
    {
        public string Name { get; private set; }
        public string Id { get; private  set; }
        public Address Address{get; private set;}
        public Customer(string id, string name)
        {
            Name = name;
            Id = id;
            Address = new Address();
        }
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}

