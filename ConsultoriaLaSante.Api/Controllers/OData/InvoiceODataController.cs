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
        public IQueryable<InvoiceModel> get([FromODataUri] string Key = null)
        {
            var list = invoiceService.getAll().Select(toInvoiceModel);
            if (!string.IsNullOrEmpty(Key))
            {
                var result = invoiceService.getAll().Where(p => p.FormNumber == Key).Select(toInvoiceModel).AsQueryable();
                return result;
            }
            
            return list.AsQueryable();
        }

        private InvoiceModel toInvoiceModel(InvoiceDto dto)
        {
            return new InvoiceModel
            {
                FormNumber = dto.FormNumber,
                BillNumber = dto.BillNumber,
                PurchaseOrder = dto.PurchaseOrder,
                Name = dto.Name,
                Nit = dto.nit,
                OrderState = dto.OrderState
            };
        }
    }
}
