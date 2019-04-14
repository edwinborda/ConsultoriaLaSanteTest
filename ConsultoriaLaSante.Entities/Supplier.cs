using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultoriaLaSante.Entities
{
    [Table("Suppliers")]
    public class Supplier 
    {
        [Key]
        public int Id { get; set; }

        public string Nit { get; set; }

        public string Name { get; set; }

    }
}
