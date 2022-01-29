using NUnit.Framework;
using Sixeyed.Extension.Library.Domain.Model;
using System;
using System.Linq;

namespace Sixeyed.Extension.Library.Tests.Demo3
{
    public class DomainModelTests
    {
        [Test]
        public void SaveChanges()
        {
            using (var container = new DomainModelContainer())
            {
                var product1 = new Product
                {
                    Name = "Item 1"
                };
                var product2 = new Product
                {
                    Name = "Item 2"
                };
                var customer = new Customer
                {
                    FirstName = "Elton",
                    LastName = "Stoneman"
                };
                var order = new Order
                {
                    Reference = Guid.NewGuid().ToString(),
                    Customer = customer
                };

                order.Products.Add(product1);
                order.Products.Add(product2);
                container.Orders.Add(order);
                container.Save();
            }
        }

        [Test]
        public void UpdateOrder()
        {
            using (var container = new DomainModelContainer())
            {
                var order = container.Orders.First();
                order.Reference += ".1";
                container.Save();
            }
        }

        [Test]
        public void UpdateProduct()
        {
            using (var container = new DomainModelContainer())
            {
                var product = container.Products.First();
                product.Name += " - new!";
                Assert.Throws<InvalidOperationException>(() => container.Save());
            }
        }
    }
}
