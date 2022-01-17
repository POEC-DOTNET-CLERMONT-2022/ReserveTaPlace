using Newtonsoft.Json;
using ReserveTaPlace.Data.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public class GenericLogic<T> : IGenericLogic<T> where T : class
    {
        public async Task<IEnumerable<T>> GetAll()
        {
            //var model = ;
            var models = new List<T>();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7091/api/{model}/all");
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            ;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    models = JsonConvert.DeserializeObject<List<T>>(jsonString);
                }
            }
            return models;
        }

        public Task<IEnumerable<T>> GetAll<P>()
        {
            throw new NotImplementedException();
        }
    }
}
