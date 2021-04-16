
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
        public void Delete(long Id)
        {
            _repository.Delete(Id);
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
