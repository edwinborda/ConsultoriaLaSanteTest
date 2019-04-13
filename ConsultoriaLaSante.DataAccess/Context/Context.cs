using ConsultoriaLaSante.Entities;
using System.Data.Entity;

namespace ConsultoriaLaSante.DataAccess.Context
{
    public class Context: DbContext
    {
        public Context() : base("name=connectionString"){}

        public DbSet<Invoice> Invoice { get; set; }
    }
}
