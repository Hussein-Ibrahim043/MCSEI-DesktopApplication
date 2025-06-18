using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Services;
using System;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Core.Models;

namespace Infrastructure.Http
{
    public static class RequestHandler
    {
        private static readonly HttpClient client = new HttpClient();

        // Adding bearer token to request headers if auth is true
        private static void AddAuthHeader()
        {
            if (!string.IsNullOrEmpty(SessionManager.AuthToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.AuthToken);
            }
        }

        public static async Task<T> PostAsync<T>(string endpoint, object body)
        {
            AddAuthHeader();

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {                
                var result = await response.Content.ReadAsStringAsync();
                //Logger.LogInfo(result);
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);                
            }
        }

        public static async Task<T> PostRadiologyAsync<T>(string endpoint, object body)
        {
            AddAuthHeader(); // Attach token/authorization header

            HttpContent content;

            if (body is HttpContent)
            {
                // Pass multipart content directly
                content = body as HttpContent;
            }
            else
            {
                var json = JsonConvert.SerializeObject(body);
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await client.PostAsync(endpoint, content);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                //Logger.LogInfo(responseBody);
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            else
            {
                Logger.LogError(responseBody);
                throw new Exception(responseBody);
            }
        }

        public static async Task<T> PatchRadiologyAsync<T>(string endpoint, object body)
        {
            AddAuthHeader(); // Attach token/authorization header

            HttpContent content;

            if (body is HttpContent)
            {
                // Pass multipart content directly
                content = body as HttpContent;
            }
            else
            {
                var json = JsonConvert.SerializeObject(body);
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint) { Content = content };
            HttpResponseMessage response = await client.SendAsync(request);
            

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                //Logger.LogInfo(responseBody);
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            else
            {
                Logger.LogError(responseBody);
                throw new Exception(responseBody);
            }
        }

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            AddAuthHeader(); // Attach token/authorization header

            HttpResponseMessage response = await client.GetAsync(endpoint);            
            if (response.IsSuccessStatusCode)
            {                
                var result = await response.Content.ReadAsStringAsync();
                //Logger.LogInfo(result);
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }

        public static async Task<T> PatchAsync<T>(string endpoint, object body)
        {
            AddAuthHeader(); // Attach token/authorization header

            string json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint){Content = content};

            HttpResponseMessage response = await client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                //Logger.LogInfo(responseContent);
                return JsonConvert.DeserializeObject<T>(responseContent);
            }else
             {
                string error = await response.Content.ReadAsStringAsync();
                Logger.LogError(error);
                throw new Exception(error);
             }            
        }             

        public static async Task<T> DeleteAsync<T>(string endpoint)
        {
            AddAuthHeader();

            HttpResponseMessage response = await client.DeleteAsync(endpoint);
            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                //Logger.LogInfo(responseContent);
                // Deserialize JSON response to T:
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            else
            {
                Logger.LogError(responseContent);
                throw new Exception($"Request failed: {response.StatusCode} - {responseContent}");
            }
        }
    }
}
