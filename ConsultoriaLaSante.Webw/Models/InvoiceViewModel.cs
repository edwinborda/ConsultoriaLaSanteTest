using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultoriaLaSante.Web.Models
{
    public class InvoiceViewModel
    {
        [Display(Name = "Número de radicado")]
        public string FormNumber { get; set; }

        [Display(Name="Número de factura")]
        [Required(ErrorMessage = "Número de factura es obligatorio")]
        public string BillNumber { get; set; }

        [Display(Name = "Orden de compra")]
        [Required(ErrorMessage = "Orden de compra es obligatorio")]
        public string PurchaseOrder { get; set; }

        [Display(Name = "Nit del proveedor")]
        [Required(ErrorMessage = "El Nit del proveedor es obligatorio")]
        public string Nit { get; set; }

        [Display(Name = "Nombre del proveedor")]
        [Required(ErrorMessage = "El Nombre del proveedor es obligatorio")]
        public string Name { get; set; }

        public int OrderState { get; set; }


    }
}