using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = dataset.SingleOrDefault(result => result.Id.Equals(entity.Id));

            if(result == null)
            {
                return null;
            }                  
             _context.Entry(result).CurrentValues.SetValues(entity);
             _context.SaveChanges();

            return entity;            
        }
        public T GetById(long Id)
        {
            return dataset.SingleOrDefault(result => result.Id.Equals(Id));
        }
        public List<T> GetAll()
        {
            return dataset.ToList();
        }       
        public void Delete(long Id)
        {
            var result = dataset.SingleOrDefault(result => result.Id.Equals(Id));
            if (result != null)
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
