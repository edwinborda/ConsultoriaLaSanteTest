using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultoriaLaSante.Web.Models
{
    public class OdataModel
    {
        public string id { get; set; }
        public List<FilterOdataModel> filters { get; set; }
    }
}