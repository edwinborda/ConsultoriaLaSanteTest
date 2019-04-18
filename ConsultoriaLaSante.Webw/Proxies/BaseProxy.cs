using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Newtonsoft.Json;
using ConsultoriaLaSante.Web.Models;

namespace ConsultoriaLaSante.Web.Proxies
{
    public class BaseProxy<TModel> where TModel:class
    {
        private readonly RestClient _restClient;
        protected  string apiUrl;
        protected  string oDataUrl;

        public BaseProxy(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public IEnumerable<TModel> get(string id = null)
        {
            RestRequest request;
            if (!string.IsNullOrEmpty(id))
                request = new RestRequest($"{apiUrl}/{id}");
            else
                request = new RestRequest(apiUrl);

            IRestResponse response = _restClient.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(response.Content);
        }

        public IEnumerable<TModel> getOData(OdataModel parameters = null)
        {
            RestRequest request = new RestRequest(oDataUrl);
            if (parameters != null)
            {
                if (!string.IsNullOrEmpty(parameters.id))
                    request = new RestRequest($"{oDataUrl}('{parameters.id}')");
                else if (parameters.filters.Any())
                {
                    
                    var filter = parameters.filters.Select(x => {
                        var val = (x.type == "Int") ? x.value : $"'{x.value}'";
                        if (x.oper == "contains")
                            return $"contains({x.field},{val})";
                        else
                            return $"{x.field} {x.oper} {val}"; 
                    });
                    request = new RestRequest($"{oDataUrl}?$filter={string.Join(" and ", filter)}");
                }   
            }
            IRestResponse response = _restClient.Execute(request);
            var outer = JsonConvert.DeserializeObject<OdataObject<TModel>>(response.Content);

            return outer.value;
        }

        public bool post(TModel model)
        {
            RestRequest request = new RestRequest(apiUrl, Method.POST);
            string modelJson = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json", modelJson, ParameterType.RequestBody);

            IRestResponse response = _restClient.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public bool put(string id, TModel model)
        {
            RestRequest request = new RestRequest($"{apiUrl}/{id}", Method.PUT);
            string modelJson = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json", modelJson, ParameterType.RequestBody);

            IRestResponse response = _restClient.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public bool delete(string id)
        {
            RestRequest request = new RestRequest($"{apiUrl}/{id}", Method.DELETE);
            IRestResponse response = _restClient.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}