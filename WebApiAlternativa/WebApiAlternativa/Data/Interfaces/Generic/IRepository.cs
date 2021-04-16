using System.Collections.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Repository.Generic
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Add (T entity);
        T Update(T entity);
        void Delete(long Id);
        T GetById(long Id);
        List<T> GetAll();
    }
}
