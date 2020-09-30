using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Web.Http;
using Newtonsoft.Json;


namespace HotelManagement.UWP.DAL.Api.HttpClient
{
    public class RestClient<T>
    {
        public System.Net.Http.HttpClient Client { get; set; }
        public Uri BaseUri { get; set; }

        public RestClient()
        {
            Client = new System.Net.Http.HttpClient();
            BaseUri = new Uri("http://localhost:55908/api/");
        }

        public async Task<List<T>> GetAll(string path)
        {
            List<T> list = null;
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.BaseAddress = BaseUri;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

                string endpoint = path;

                try
                {

                    System.Net.Http.HttpResponseMessage response = await httpClient.GetAsync(endpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        
                        try
                        {
                            list = JsonConvert.DeserializeObject<List<T>>(jsonResponse);

                        }
                        catch (JsonSerializationException exception)
                        {
                            

                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                return list ; 
            }
        }
        public async Task<T> Get(string path)
        {
            T entity = default(T);
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.BaseAddress = BaseUri;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

                string endpoint = path;

                try
                {
                   
                    System.Net.Http.HttpResponseMessage response = await httpClient.GetAsync(endpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        try
                        {
                            entity = JsonConvert.DeserializeObject<T>(jsonResponse);

                        }
                        catch (JsonSerializationException exception)
                        {


                        }
                    }
                }
                catch (Exception)
                {
                    return default(T);
                }
                return entity;
            }
        }
        public async Task<bool> Add(string path, T entity)
        {

            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.BaseAddress = BaseUri;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

                string endpoint = path;

                try
                {
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                    System.Net.Http.HttpResponseMessage response = await httpClient.PostAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        //do something with json response here
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> Update(string path,T entity)
        {
            var url = BaseUri + path;
            
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.BaseAddress = BaseUri;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

                string endpoint = path;

                try
                {
                    var serialized = JsonConvert.SerializeObject(entity);
                    HttpContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    System.Net.Http.HttpResponseMessage response = await httpClient.PutAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        //do something with json response here
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }



     
    }
}
