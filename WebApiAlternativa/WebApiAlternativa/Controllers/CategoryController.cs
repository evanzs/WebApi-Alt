using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAlternativa.Data.Bussiness;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBusiness _categoryBusiness;

        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryBusiness.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_categoryBusiness.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(Category category)
        {
            return Ok(_categoryBusiness.Add(category));
        }
        [HttpPut]
        public IActionResult Update([FromBody] Category category)
        {
            return Ok(_categoryBusiness.Update(category));
        }
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _categoryBusiness.Delete(id);
        }

    }
}
