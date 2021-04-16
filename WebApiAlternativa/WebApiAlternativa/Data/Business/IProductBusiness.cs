using System.Collections.Generic;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Bussiness
{
    public interface IProductBusiness
    {
        Product Add(Product product);
        Product Update(Product product);
        void Delete(long Id);
        Product GetById(long Id);
        List<Product> GetAll();
    }
}
