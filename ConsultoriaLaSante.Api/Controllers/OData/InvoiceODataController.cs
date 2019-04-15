using ConsultoriaLaSante.Api.Models;
using ConsultoriaLaSante.Dtos;
using ConsultoriaLaSante.Services.Interfaces;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace ConsultoriaLaSante.Api.Controllers.OData
{

    /// <summary>
    /// Endopoint OData invoice
    /// </summary>
    
    
    public class InvoiceODataController : ODataController
    {
        private readonly IInvoiceService invoiceService;

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="invoiceService"></param>
        public InvoiceODataController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }
        /// <summary>
        /// get queryable invoices
        /// </summary>
        /// <returns></returns>

        [EnableQuery]
        [ResponseType(typeof(InvoiceModel))]
        [HttpGet]
        public IQueryable<InvoiceModel> get()
        {
            var list = invoiceService.getAll().Select(toInvoiceModel);
            return list.AsQueryable();
        }

        private InvoiceModel toInvoiceModel(InvoiceDto dto)
        {
            return new InvoiceModel
            {
                FormData = dto.FormNumber,
                BillOrder = dto.BillNumber,
                PurchaseOrder = dto.PurchaseNumber,
                Name = dto.Name,
                Nit = dto.nit
            };
        }
    }
}
