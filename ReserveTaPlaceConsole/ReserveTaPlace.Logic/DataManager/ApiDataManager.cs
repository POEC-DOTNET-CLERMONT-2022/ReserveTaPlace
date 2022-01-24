using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic.DataManager
{
    public abstract class ApiDataManager<TModel, TDto> : IDataManager<TModel, TDto> where TModel : class where TDto : class , new()
    {
        private HttpClient HttpClient { get; }
        private IMapper Mapper { get; }
        private string ServerUrl { get; }
        private string ResourceUrl { get; }

        private Uri Uri { get; }
        public ApiDataManager(HttpClient client, IMapper mapper, string serverUrl, string resourceUrl)
        {
            HttpClient = client;
            Mapper = mapper;
            ServerUrl = serverUrl;
            ResourceUrl = resourceUrl;
            Uri = new Uri(ServerUrl + ResourceUrl);
        }


        public async Task<IEnumerable<TModel>> GetAll()
        {
            var result = await HttpClient.GetFromJsonAsync<IEnumerable<TDto>>(Uri);
            return Mapper.Map<IEnumerable<TModel>>(result);
        }

        public async Task Add(TModel model)
        {
            var dto = Mapper.Map<TDto>(model);
            await HttpClient.PostAsJsonAsync(Uri, dto);
        }

        public async Task<TModel> GetMovie()
        {
            var result = new TDto();
            var test = await HttpClient.GetAsync(Uri);
            //var result = await HttpClient.GetFromJsonAsync<TDto>(Uri);
            HttpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            var request = new HttpRequestMessage() { 
                Method= HttpMethod.Post,
                RequestUri = Uri
            };
            request.Headers.Add("Accept", "*/*");
            using (var response = await HttpClient.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TDto>(body);
            }
            //var ImdbDto = System.Text.Json.JsonSerializer.Deserialize<TDto>(dtoStrg);
            //var ImdbDto = await HttpClient.GetFromJsonAsync<TDto>(Uri);
            return Mapper.Map<TModel>(result);
        }
    }
}
