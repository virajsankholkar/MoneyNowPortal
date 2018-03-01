using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    public class RESTClient<T>
    {
        private string _ServiceUrl;

        public RESTClient()
        {            
        }

         public RESTClient(string webAPIURL)
        {
            _ServiceUrl = webAPIURL;
        }

        public string ServiceUrlConfig
        {
            get {
                return _ServiceUrl;
            }
            set
            {
                value = _ServiceUrl;
            }
        }        

        public async Task<T> PostAsync(object request, string urlParameters)
        {
            string url = _ServiceUrl + urlParameters;

            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(request);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                try
                {
                    using (HttpResponseMessage response = await client.PostAsync(url, content))
                    {
                        if ((int)response.StatusCode == (int)HttpStatusCode.OK || (int)response.StatusCode == (int)HttpStatusCode.Created || (int)response.StatusCode == (int)HttpStatusCode.Accepted || (int)response.StatusCode == (int)HttpStatusCode.NoContent)
                        {
                            using (HttpContent responseContent = response.Content)
                            {
                                string result = await responseContent.ReadAsStringAsync();                                
                                var r = JsonConvert.DeserializeObject<T>(result);
                                return r;
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }

                    }
                }
                catch (Exception ex)
                {
                    //TODO: Catch Exception.
                    string errorMessage = ex.Message;
                    var r = JsonConvert.DeserializeObject<T>("");
                    return r;
                }
            }
        }

        public async Task<TResult> GetAsync<TResult>(string uriString) where TResult : class
        {
            var uri = new Uri(uriString);
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //Log.Error(response.ReasonPhrase);
                        return default(TResult);
                    }
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<TResult>(json, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                }
                catch (Exception ex)
                {
                    //TODO: Catch Exception.
                    var r = JsonConvert.DeserializeObject<TResult>(ex.Message);
                    return r;
                }
            }
        }      
    }
}