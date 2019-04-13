using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultoriaLaSante.Dtos
{
    public class InvoiceDto
    {
        public Guid FormNumber { get;  set; }

        public string OrderNumber { get; set; }

        public string BillNumber { get; set; }

        public int Supplier_id { get; set; }

        public int OrderState { get; set; }

        public int nit { get; set; }

        public string Name { get; set; }
    }
}
