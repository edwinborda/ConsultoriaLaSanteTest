using ConsultoriaLaSante.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ConsultoriaLaSante.Web.Proxies
{
    public class InvoicesProxy: BaseProxy<InvoiceViewModel>
    {
        public InvoicesProxy()
        {
            baseUrl = ConfigurationManager.AppSettings["baseUrl"] ?? throw new ArgumentException("No existe llave baseUrl");
            apiUrl = "/api/Invoices";
            oDataUrl = "/odata/InvoiceOdata";
        }

    }
}