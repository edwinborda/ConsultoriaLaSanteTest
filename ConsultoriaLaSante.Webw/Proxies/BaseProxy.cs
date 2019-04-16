using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace ConsultoriaLaSante.Web.Proxies
{
    public class BaseProxy<TModel> where TModel:class
    {
        private readonly RestClient _restClient;
        protected  string baseUrl;
        protected  string apiUrl;
        protected  string oDataUrl;

        public BaseProxy()
        {
            _restClient = new RestClient(baseUrl);
        }

        public IEnumerable<TModel> get(string path = null)
        {
            RestRequest request;
            if (!string.IsNullOrEmpty(path))
                request = new RestRequest($"{apiUrl}/{path}");
            else
                request = new RestRequest(apiUrl);

            IRestResponse response = _restClient.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(response.Content);
        }

        public IEnumerable<TModel> getOData(Dictionary<string, Dictionary<string, string>> parameters)
        {
            RestRequest request = new RestRequest(oDataUrl);
            if (parameters.FirstOrDefault(it => it.Key == "id").Value.Any())
                request = new RestRequest($"{oDataUrl}({parameters.FirstOrDefault(it => it.Key == "id").Value["Id"]})");
            else if (parameters.FirstOrDefault(it => it.Key == "filter").Value.Any())
            {
                var dictionary = parameters.FirstOrDefault(it => it.Key == "filter").Value;
                var filter = dictionary.Select(x => $"{x.Key} eq {x.Value}");

                request = new RestRequest($"{oDataUrl}?$filter={string.Join("and", filter) }");
            }
            IRestResponse response = _restClient.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(response.Content);
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