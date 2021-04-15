
using System.Collections.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Bussiness
{
    public interface IProductBusiness
    {
        Product Add(Product product);
        Product Update(Product product);
        void Delete(long id);
        Product GetById(long id);
        List<Product> GetAll();
    }
}
