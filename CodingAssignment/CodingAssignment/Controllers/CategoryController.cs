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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _service;
        public CategoryController(ICategory service)
        {
            _service = service;
        }

        [HttpGet]
        public CAResponse GetAllCategorys()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public CAResponse GetCategoryById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public CAResponse Create([FromBody] CategoryRequest category)
        {
            return _service.Create(category);
        }

        [HttpPut]
        public CAResponse Edit([FromBody] CategoryRequest category)
        {
            return _service.Edit(category);
        }

        [HttpDelete("{id}")]
        public CAResponse Delete([FromRoute] int id)
        {
            return _service.Delete(id);
        }
    }
}