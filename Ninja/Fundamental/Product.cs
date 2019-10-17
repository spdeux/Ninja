using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Mocking
{
    public class Product
    {
        public float ListPrice { get; set; }

        public float GetPrice(Customer customer)
        {
            if (customer.IsGold)
                return ListPrice * .7f;

            return ListPrice;

        }
    }
}
