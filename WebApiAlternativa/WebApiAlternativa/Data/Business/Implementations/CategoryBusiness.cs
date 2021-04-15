
using System.Collections.Generic;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Entities;
using WebApiAlternativa.Data.Bussiness;

namespace WebApiAlternativa.Data.Business.Implementaions
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IRepository<Category> _repository;

        public CategoryBusiness (IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Category Add (Category category)
        {
            return _repository.Add(category);
        }
        public Category Update(Category category)
        {
            return _repository.Update(category);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        public Category GetById(long id)
        {
            return _repository.GetById(id);
        }
        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
