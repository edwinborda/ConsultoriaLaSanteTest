using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultoriaLaSante.Entities
{
    [Table("Supplierss")]
    public class Supplier 
    {
        public int Id { get; set; }

        public int Nit { get; set; }

        public string Name { get; set; }

    }
}
