using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.MVC.Repository
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }
        public Uri URL { get; set; }
        public ServiceRepository()
        {
            Client = new HttpClient();
            URL = new Uri("https://localhost:44399/api/Employees");
        }
          
   
        public HttpResponseMessage GetResponse()
        {
            return Client.GetAsync(URL).Result;
        }
        public HttpResponseMessage PutResponse(object model)
        {
            var content = JsonConvert.SerializeObject(model);
            return Client.PutAsync(URL, new StringContent(content, Encoding.Default, "application/json")).Result;
        }
        public HttpResponseMessage PostResponse(object model)
        {
            var content = JsonConvert.SerializeObject(model);
            return Client.PostAsync(URL, new StringContent(content, Encoding.Default, "application/json")).Result;
        }
        public HttpResponseMessage DeleteResponse(int id)
        {
            return Client.DeleteAsync($"{URL}?id={id}").Result;
        }
    }
}
