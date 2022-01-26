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
            var models = new List<T>();
            var modelName = typeof(T).Name;

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7091/api/{modelName}");
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
    }
}
