using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlternativa.Context;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Data.Repository.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AlternativaContext _context;
        protected readonly DbSet<T> dataset;
        public Repository(AlternativaContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public T Add(T entity)
        {
             dataset.Add(entity);
            _context.SaveChanges();

            return entity;
        }
        public T Update(T entity)
        {
            var result = dataset.SingleOrDefault(result => result.id.Equals(entity.id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).State = EntityState.Modified;
                    _context.SaveChanges();
                    return entity;
                }
                catch(Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
          
        }
        public T GetById(long id)
        {
            return dataset.SingleOrDefault(result => result.id.Equals(id));

        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }       
        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(result => result.id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}
