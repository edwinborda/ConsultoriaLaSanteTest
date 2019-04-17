using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultoriaLaSante.Web.Models
{
    public class OdataObject<TModel> where TModel:class
    {
        [JsonProperty("@odata.context")]
        public string context { get; set; }
        public List<TModel> value { get; set; }
    }
}