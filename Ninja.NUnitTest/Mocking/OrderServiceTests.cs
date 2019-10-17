using Moq;
using Ninja.Mocking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.NUnitTest
{

    public class OrderServiceTests
    {
        private Mock<IStorage> _storage;
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IStorage>();
            _orderService = new OrderService(_storage.Object);
        }


        [Test] //State-based test : it test the implementation of code
        public void PlaceOrder_WhenCalledWithTheSpecificOrder_ReturnSavedOrderId()
        {
            //Arrange
            var order = new Order() { Id = 45 };
            _storage.Setup(x => x.Store(order)).Returns(45);


           //Act
            int orderId = _orderService.PlaceOrder(order);


            //assert
            Assert.AreEqual(orderId, 45);
        }

        [Test] //interaction test: it test our expectation. ex) we expect Store(order) Called when we call PlaceOrder(order)
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            //Arrange
            var order = new Order();

            //Act
            _orderService.PlaceOrder(order);


            //Assert
            _storage.Verify(st => st.Store(order));
        }
    }
}
