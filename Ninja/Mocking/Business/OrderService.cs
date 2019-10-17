using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Mocking
{
    public class OrderService
    {
        private readonly IStorage _storage;

        public OrderService(IStorage storage)
        {
            _storage = storage;
        }

        public int PlaceOrder(Order order)
        {
            var orderId = _storage.Store(order);
            return orderId;
        }
    }
}
