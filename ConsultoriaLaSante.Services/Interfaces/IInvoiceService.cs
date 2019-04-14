using ConsultoriaLaSante.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultoriaLaSante.Services.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<InvoiceDto> getAll();

        InvoiceDto GetInvoice(string formNumber);

        bool Update(InvoiceDto dto);

        bool removeOrder(string formNumber);

        bool createInvoice(InvoiceDto model);
       
    }
}
