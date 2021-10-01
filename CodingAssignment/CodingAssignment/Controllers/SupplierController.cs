using CodingAssignment.Database;
using CodingAssignment.Interface;
using Microsoft.AspNetCore.Mvc;
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
        public List<Supplier> GetAllSuppliers()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public Supplier GetSupplierById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Supplier Create([FromBody] Model.Request.Supplier suplier)
        {
            return _service.Create(suplier);
        }
    }
}
