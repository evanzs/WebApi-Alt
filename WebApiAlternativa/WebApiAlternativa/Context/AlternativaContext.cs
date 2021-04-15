using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlternativa.Entities;

namespace WebApiAlternativa.Context
{
    public class AlternativaContext :DbContext   
    {   

        public AlternativaContext(DbContextOptions<AlternativaContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
