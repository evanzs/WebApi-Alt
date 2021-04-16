
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAlternativa.Entities
{
    public class BaseEntity
    {
        [Column("{id}")]
        public long Id { get; set; }
        [Column("{name}")]
        public string Name { get; set; }
        [Column("{description}")]
        public string Description { get; set; }
    }
}
