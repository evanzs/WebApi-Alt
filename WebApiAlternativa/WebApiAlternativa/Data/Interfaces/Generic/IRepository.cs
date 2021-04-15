using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Repository.Generic
{
    public interface IRepository<T> where T: BaseEntity
    {

        T Add (T entity);
        T Update(T entity);
        void Delete(long id);
        T GetById(long id);
        List<T> GetAll();
    }
}
