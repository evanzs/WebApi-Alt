using Microsoft.AspNetCore.Mvc;
using System;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;            
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoryRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500,"");
            }
        }
        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            try
            {
                  return Ok(_categoryRepository.GetById(Id));
            }
            catch (Exception)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost]
        public IActionResult Post(Category category)
        {
            try
            {
                _categoryRepository.Add(category);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] Category category)
        {
            try
            {
                Category result = _categoryRepository.GetById(category.Id);

                if ( result == null)
                {
                    return StatusCode(400, "");
                }

                return Ok(_categoryRepository.Update(category));
                
            }
            catch (Exception)
            {

                return StatusCode(500, "");
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            try
            {
                _categoryRepository.Delete(Id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "");
            }
        }

    }
}
