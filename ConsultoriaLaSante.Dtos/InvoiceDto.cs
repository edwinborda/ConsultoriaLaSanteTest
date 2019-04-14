using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultoriaLaSante.Dtos
{

    /// <summary>
    /// Invoice Dto
    /// </summary>
    public class InvoiceDto
    {
        public string FormNumber { get;  set; }

        public string PurchaseNumber { get; set; }

        public string BillNumber { get; set; }

        public int Supplier_id { get; set; }

        public int OrderState { get; set; }

        public string nit { get; set; }

        public string Name { get; set; }
    }
}
