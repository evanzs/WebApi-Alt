using System.Collections.Generic;
using System.Linq;
using WebApiAlternativa.Data.Bussiness;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Business.Implementaions
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Category> _repositoryCategory;
        public ProductBusiness (IRepository<Product> repository,IRepository<Category> repositoryCategory)
        {
            _repository = repository;
            _repositoryCategory = repositoryCategory;
        }

        public Product Add(Product product)
        {
            if ( product.CategoryId != null)
            {
                //long categoryId = (long)product.CategoryId;
                //Category category = _repositoryCategory.GetById(categoryId);
                //if (category != null)
                //{
                //    return "Erro"
                //}

            }
            return _repository.Add(product);
        }
        public Product Update(Product product)
        {
            return _repository.Update(product);
        }
        public void Delete(long Id)
        {
            Product product = _repository.GetById(Id);

            if (product != null)
            {
                if (product?.CategoryId == null)
                {
                    _repository.Delete(Id);
                }
            }
            
        }
        public Product GetById(long Id)
        {
            Product product =_repository.GetById(Id);
            //verifica se existe retorno
            if (product == null)
            {
                return null;
            }               

            //verifica ta vinculado a categoria
            //se sim: inclue categoria em produto
            if(product.CategoryId != null)
            {
                long categoryId = (long)product.CategoryId;
                product.Category = _repositoryCategory.GetById(categoryId);
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
                    product.Category = _repositoryCategory.GetById(categoryId);
                }
            }
            return products;
        }

    }
}
