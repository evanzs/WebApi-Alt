using System;
using System.Collections.Generic;
using WebApiAlternativa.Data.Bussiness;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Business.Implementaions
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IRepository<Product> _repository;
        public ProductBusiness (IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product Add(Product product)
        {
            return _repository.Add(product);
        }
        public Product Update(Product product)
        {
            return _repository.Update(product);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        public Product GetById(long id)
        {
            return _repository.GetById(id);
        }
        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
