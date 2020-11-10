using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenCommon.Services.Restful.Constants;

namespace OpenCommon.Services.Restful.Utilities
{
    public static class RequestHelper
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        
        public static async Task<TResult> SendRequest<TResult>(string url, string httpMethod = HttpMethods.Get, object request = null)
        {
            var requestJson = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(requestJson);

            TResult result;
            switch (httpMethod)
            {
                case HttpMethods.Get:
                    using (var response = await HttpClient.GetAsync(url))
                    {
                        result = await HandleResponse<TResult>(response);
                    }
                    break;
                case HttpMethods.Post:
                    using (var response = await HttpClient.PostAsync(url, httpContent))
                    {
                        result = await HandleResponse<TResult>(response);
                    }
                    break;
                case HttpMethods.Put:
                    using (var response = await HttpClient.PutAsync(url, httpContent))
                    {
                        result = await HandleResponse<TResult>(response);
                    }
                    break;
                case HttpMethods.Delete:
                    using (var response = await HttpClient.DeleteAsync(url))
                    {
                        result = await HandleResponse<TResult>(response);
                    }
                    break;
                default:
                    throw new NotSupportedException($"BaseConnector.SendRequest does not support {httpMethod}.");
            }

            return result;
        }

        private static async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<T>(result);
            return responseJson;
        }
    }
}
