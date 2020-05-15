using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServerDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrpcClientDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly Order.OrderClient _orderClient;

        public DefaultController(Order.OrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var order = await _orderClient.GetOrderAsync(new OrderRequest { OrderNo = "20200102009999" });
            return Ok(order);
        }
    }
}
