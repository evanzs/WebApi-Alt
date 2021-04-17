using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAlternativa.Entities
{
    [Table("Produto")]
    public class Product:BaseEntity 
    {  
        public decimal? Value { get; set; }
        public string Brand { get; set; }

        [ForeignKey("Categoria")]      
        [Column("category_id")]
        public long? CategoryId { get; set; }
        public virtual Category Category { get; set; }
}
}
