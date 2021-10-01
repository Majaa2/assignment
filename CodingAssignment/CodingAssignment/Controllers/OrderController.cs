using CodingAssignment.Database;
using CodingAssignment.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _service;
        public OrderController(IOrder service)
        {
            _service = service;
        }

        [HttpGet]
        public CAResponse GetAllOrders()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public CAResponse GetOrderById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public CAResponse Create([FromBody] OrderRequest order)
        {
            return _service.Create(order);
        }

        [HttpPut]
        public CAResponse Edit([FromBody] OrderRequest order)
        {
            return _service.Edit(order);
        }

        [HttpDelete("{id}")]
        public CAResponse Delete([FromRoute] int id)
        {
            return _service.Delete(id);
        }
    }
}