using Microsoft.AspNetCore.Mvc;
using WebApiAlternativa.Data.Bussiness;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _productBusiness;
        public ProductController (IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productBusiness.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_productBusiness.GetById(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            return Ok(_productBusiness.Add(product));
        }
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            return Ok(_productBusiness.Update(product));
        }
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _productBusiness.Delete(id);
        }

    }
}
