using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;

namespace API.Tests
{
    public class UnitTest1
    {
        private readonly OrdersController _orders;
        public UnitTest1()
        {
            _orders = new OrdersController();
        }
        [Fact]
        public async void Test1()
        {
            var okResult = await _orders.Get();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
