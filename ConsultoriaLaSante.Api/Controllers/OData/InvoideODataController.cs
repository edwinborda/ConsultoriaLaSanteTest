using ConsultoriaLaSante.Api.Models;
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
    [EnableQuery]
    public class InvoideODataController : ODataController
    {
        private readonly IInvoiceService invoiceService;

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="invoiceService"></param>
        public InvoideODataController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }
        /// <summary>
        /// get queryable invoices
        /// </summary>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(InvoiceModel))]
        public IHttpActionResult get()
        {
            return Ok(invoiceService.getAll().AsQueryable());
        }
    }
}
