using ConsultoriaLaSante.DataAccess;
using ConsultoriaLaSante.DataAccess.Context;
using ConsultoriaLaSante.DataAccess.Repositories;
using ConsultoriaLaSante.Dtos;
using ConsultoriaLaSante.Entities;
using ConsultoriaLaSante.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsultoriaLaSante.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceRepository invoiceRepository;
        private readonly UnityOfWork unityOfWork;
        public InvoiceService()
        {
            var ctx = new Context();
            invoiceRepository = new InvoiceRepository(ctx);
            unityOfWork = new UnityOfWork(ctx);
        }
        public bool removeOrder(string formNumber)
        {
            var entity = invoiceRepository.GetEntity(formNumber);
            entity.changeStatus(Invoice.State.delete);
;           invoiceRepository.Update(entity);

            return unityOfWork.Save();
        }

        public IEnumerable<InvoiceDto> getAll()
        {
            return invoiceRepository.getAll("Supplier").Select(toInvoiceDto);
        }

        public InvoiceDto GetInvoice(string formNumber)
        {
            return toInvoiceDto(invoiceRepository.GetEntity(formNumber));
        }

        public bool Update(InvoiceDto dto)
        {
            var entity = toInvoice(dto);
            invoiceRepository.Update(entity);

            return unityOfWork.Save();
        }

        public bool createInvoice(InvoiceDto model)
        {
            var entity = toInvoice(model);
            invoiceRepository.Insert(entity);

            return unityOfWork.Save();
        }

        private InvoiceDto toInvoiceDto(Invoice invoice)
        {
            return new InvoiceDto()
            {
                FormNumber = invoice.FormNumber.ToString(),
                BillNumber = invoice.BillNumber,
                Name = invoice.Supplier.Name,
                nit = invoice.Supplier.Nit,
                PurchaseOrder = invoice.PurchaseNumber,
                OrderState = (int)invoice.OrderState
            };
        }

        private Invoice toInvoice(InvoiceDto model)
        {
            return new Invoice(model.PurchaseOrder, model.BillNumber, model.nit, model.Name, model.FormNumber);
        }
    }
}
