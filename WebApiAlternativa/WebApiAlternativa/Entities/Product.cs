using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAlternativa.Entities
{
    [Table("Produtos")]
    public class Product:BaseEntity 
    {  
        public decimal? value { get; set; }
        public string brand { get; set; }

        [ForeignKey("Categorias")]      
        [Column("category_id")]
        public long? categoryId { get; set; }
        public virtual Category category { get; set; }
}
}
