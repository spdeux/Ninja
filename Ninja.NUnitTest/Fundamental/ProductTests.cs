using Ninja.Mocking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.NUnitTest
{
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldeCustomer_Apply30PercentDiscount()
        {
            var product = new Product() { ListPrice = 100 };

            var result = product.GetPrice(new Customer() { IsGold = true });

            Assert.That(result, Is.EqualTo(70));
        }
    }
}
