using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultoriaLaSante.Api.Models
{
    /// <summary>
    /// Invoice Model
    /// </summary>
    public class InvoiceModel
    {
        /// <summary>
        /// Form Number is created aleatory form
        /// </summary>
        [Key]
        public string FormNumber { get; set; }
        /// <summary>
        /// Biil order number
        /// </summary>
        [Required(ErrorMessage = "The bill number is required")]
        public string BillNumber { get; set; }

        /// <summary>
        /// Purchase order
        /// </summary>
        [Required(ErrorMessage = "The purchase order is required")]
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Supplier's nit
        /// </summary>
        [Required(ErrorMessage = "The supplier's Nit is required")]
        [MaxLength(15, ErrorMessage ="The length of the supplier's Nit is exceeds the limit")]
        public string Nit { get; set; }

        /// <summary>
        /// Supplier's name
        /// </summary>
        [Required(ErrorMessage ="The supplier's name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Form's state
        /// </summary>
        public int OrderState { get; set; }
    }
}