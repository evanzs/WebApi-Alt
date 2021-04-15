using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Bussiness
{
    public interface ICategoryBusiness
    {       
        Category Add(Category category);
        Category Update(Category category);      
        void Delete(long id);
        Category GetById(long id);
        List<Category> GetAll();
    }
}
