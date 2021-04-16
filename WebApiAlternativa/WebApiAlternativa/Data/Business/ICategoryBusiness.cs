using System.Collections.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Bussiness
{
    public interface ICategoryBusiness
    {       
        Category Add(Category category);
        Category Update(Category category);
        bool Delete(long Id);
        Category GetById(long Id);
        List<Category> GetAll();
    }
}
