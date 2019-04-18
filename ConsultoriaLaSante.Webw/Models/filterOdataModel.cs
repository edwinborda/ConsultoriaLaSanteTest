using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultoriaLaSante.Web.Models
{
    public class FilterOdataModel
    {
        public string field { get; set; }

        public string oper { get; set; }

        public string value { get; set; }

        public string type { get; set; }
    }
}