using Microsoft.AspNetCore.Mvc;
using WebApiAlternativa.Data.Bussiness;
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
        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            return Ok(_categoryBusiness.GetById(Id));
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
        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            if (_categoryBusiness.Delete(Id))
            {
                return Ok();
            }

            return Conflict();
        }

    }
}
