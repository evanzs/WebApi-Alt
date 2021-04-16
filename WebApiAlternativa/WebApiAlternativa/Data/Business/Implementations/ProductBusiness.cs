using System.Collections.Generic;
using WebApiAlternativa.Data.Bussiness;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Business.Implementaions
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Category> _categoryRepository;
        public ProductBusiness (IRepository<Product> repository,IRepository<Category> categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public Product Add(Product product)
        {           
            return _repository.Add(product);
        }
        public Product Update(Product product)
        {
            return _repository.Update(product);
        }
        public void Delete(long Id)
        {
            _repository.Delete(Id);           
        }
        public Product GetById(long Id)
        {
            Product product =_repository.GetById(Id);
            //verifica se existe retorno
            if (product == null)
            {
                return null;
            }
            //verifica se há vinculo com categoria
            //se sim: inclue categoria em produto
            if(product.CategoryId != null)
            {
                long categoryId = (long)product.CategoryId;
                product.Category = _categoryRepository.GetById(categoryId);
            }

            return product;
        }
        public List<Product> GetAll()
        {
            List<Product> products = _repository.GetAll();
            if (products == null)
            {
                return null;
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
            return products;
        }

    }
}
