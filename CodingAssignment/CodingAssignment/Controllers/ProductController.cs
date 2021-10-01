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
    public class ProductController : ControllerBase
    {
        private readonly IProduct _service;
        public ProductController(IProduct service)
        {
            _service = service;
        }

        [HttpPost]
        public CAResponse GetAllProducts([FromBody] ProductQuery args)
        {
            return _service.Get(args.CategoryId, args.SupplierId);
        }

        [HttpGet("{id}")]
        public CAResponse GetProductById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpPost("create")]
        public CAResponse Create([FromBody] ProductRequest product)
        {
            return _service.Create(product);
        }

        [HttpPut]
        public CAResponse Edit([FromBody] ProductRequest product)
        {
            return _service.Edit(product);
        }

        [HttpDelete("{id}")]
        public CAResponse Delete([FromRoute] int id)
        {
            return _service.Delete(id);
        }
    }

    public class ProductQuery
    {
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}
