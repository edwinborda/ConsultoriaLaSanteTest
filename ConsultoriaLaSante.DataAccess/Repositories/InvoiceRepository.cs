using ConsultoriaLaSante.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultoriaLaSante.DataAccess.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>
    {
        public InvoiceRepository(Context.Context ctx) : base(ctx)
        {

        }

    }
}
