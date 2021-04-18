using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        public ProductController (IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {

            List<Product> products = _productRepository.GetAll();

            if (products == null)
            {
                return Ok(products);
            }
            //relacionando produtos a categorias
            foreach (Product product in products)
            {
                if (product.CategoryId != null)
                {
                    long categoryId = (long)product.CategoryId;
                    product.Category = _categoryRepository.GetById(categoryId);
                }
            }
            return Ok(products);            
        }
        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            Product product = _productRepository.GetById(Id);
            //verifica se existe retorno
            if (product == null)
            {
                return Ok(product);
            }
            //verifica se há vinculo com categoria
            //se sim: inclue categoria em produto
            if (product.CategoryId != null)
            {
                long categoryId = (long)product.CategoryId;
                product.Category = _categoryRepository.GetById(categoryId);
            }

            return Ok(product);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _productRepository.Add(product);
                return StatusCode(201);
            }
            catch (Exception)
            {

                return StatusCode(500, "");
            }

            
        }
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            try
            {
                Product result = _productRepository.Update(product);
                if(result.CategoryId != null)
                {
                    result.Category = _categoryRepository.GetById((long)result.CategoryId);
                }
                return Ok(result);
            }
            catch (Exception)
            {
               return StatusCode(500, "");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long Id)
        {
            try
            {
                _productRepository.Delete(Id);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500,"");
            }
        }

    }
}
