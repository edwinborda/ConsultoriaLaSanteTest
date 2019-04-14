using ConsultoriaLaSante.Api.Models;
using ConsultoriaLaSante.Dtos;
using ConsultoriaLaSante.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ConsultoriaLaSante.Api.Controllers
{
    /// <summary>
    /// Api gets about invoices
    /// </summary>
    [RoutePrefix("api/invoices")]
    public class InvoiceController : ApiController
    {
        private readonly IInvoiceService invoiceService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="invoiceService"></param>
        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <remarks>
        /// Get a list of invoices
        /// </remarks>
        /// <returns></returns>
        /// <response code ="200">It's ok</response>
        [ResponseType(typeof(IEnumerable<InvoiceModel>))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult get()
        {
            return Ok(invoiceService.getAll());
        }

        /// <summary>
        /// create a new invoice
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        /// <response code ="200">It's ok</response>
        /// <response code ="400">Bad request, check the model</response>
        /// <response code ="500">Ups, the server had an error</response>
        [ResponseType(typeof(InvoiceModel))]
        [Route("")]
        [HttpPost]
        public IHttpActionResult post([FromBody] InvoiceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new InvoiceDto()
            {
                PurchaseNumber = model.PurchaseOrder,
                BillNumber = model.BillOrder,
                nit = model.Nit,
                Name = model.Name
            };

            if (!invoiceService.createInvoice(dto))
                return InternalServerError();

            return Ok();
        }


        /// <summary>
        /// update a specific invoice
        /// </summary>
        /// <param name="id">guid invoice</param>
        /// <param name="model">model invoice</param>
        /// <returns></returns>
        /// <response code ="200"></response>
        /// <response code ="400">Bad request, check the model</response>
        /// <response code ="500">Ups, the server had an error</response>
        /// <response code ="404">the form guid doesn't exist</response>
        [ResponseType(typeof(InvoiceModel))]
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult put(string id, [FromBody] InvoiceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new InvoiceDto()
            {
                FormNumber =  id,
                PurchaseNumber = model.PurchaseOrder,
                BillNumber = model.BillOrder,
                nit = model.Nit,
                Name = model.Name
            };

            if (!invoiceService.Update(dto))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Remove invoice, really change status
        /// </summary>
        /// <param name="id">guid invoice</param>
        /// <returns></returns>
        /// <response code ="200"></response>
        /// <response code ="400">Bad request, check the model</response>
        /// <response code ="500">Ups, the server had an error</response>
        /// <response code ="404">the form guid doesn't exist</response>
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            if (invoiceService.GetInvoice(id) == null)
                return NotFound();

            if (!invoiceService.removeOrder(id))
                return InternalServerError();

            return Ok();
        }

    }
}
