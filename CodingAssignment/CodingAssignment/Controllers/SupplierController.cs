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

    public class SupplierController : ControllerBase
    {
        private readonly ISupplier _service;
        public SupplierController(ISupplier service)
        {
            _service = service;
        }

        [HttpGet]
        public CAResponse GetAllSuppliers()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public CAResponse GetSupplierById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public CAResponse Create([FromBody] SupplierRequest supplier)
        {
            return _service.Create(supplier);
        }

        [HttpPut]
        public CAResponse Edit([FromBody] SupplierRequest supplier)
        {
            return _service.Edit(supplier);
        }

        [HttpDelete("{id}")]
        public CAResponse Delete([FromRoute] int id)
        {
            return _service.Delete(id);
        }
    }
}
