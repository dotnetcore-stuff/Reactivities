using System;
using System.Threading;
using System.Threading.Tasks;
using API.Kafka;
using API.Services;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<Boolean>> Get()
        {
            Console.WriteLine("I Tested here");
            var result = await Task.Run(() => "Test Successful");
            // var store = new ProcessOrders();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync() 
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            SampleStore store = new SampleStore();
            var result = await store.Publish("value");
            return Created($"OrderID: {"value"}", $"Order Status: {result}");
        }
        
    }
}