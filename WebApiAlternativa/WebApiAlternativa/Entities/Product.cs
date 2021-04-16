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
        public decimal? Value { get; set; }
        public string Brand { get; set; }

        [ForeignKey("Categorias")]      
        [Column("category_id")]
        public long? CategoryId { get; set; }
        public virtual Category Category { get; set; }
}
}
