using System.Collections.Generic;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;
using WebApiAlternativa.Data.Bussiness;

namespace WebApiAlternativa.Data.Business.Implementaions
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IRepository<Category> _repository;
        private readonly IRepository<Product> _productRepository;

        public CategoryBusiness (IRepository<Category> repository, IRepository<Product> productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public Category Add (Category category)
        {
            return _repository.Add(category);
        }
        public Category Update(Category category)
        {
            return _repository.Update(category);
        }
        public bool Delete(long Id)
        {
            //buscar lista de produtos existentes para procurar relação
            //Nota: normalmente faria isso no repository de categoria para consultar direto na tabela de produtos,
            //como a aplicação é pequena faria essa verificação por lista de produtos
            List<Product> products = _productRepository.GetAll();
            //procura se há algum produto ligado a categoria
            Product result = products.Find(product => product.CategoryId.Equals(Id));       
            if( result != null)
            {
                return false;
            }

            _repository.Delete(Id);
            return true;
        }
        public Category GetById(long Id)
        {
            return _repository.GetById(Id);
        }
        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
