﻿using AutoMapper;
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

        public async Task<bool> Add(TModel model)
        {
            var result = await HttpClient.PostAsJsonAsync(Uri, model);
            return result.IsSuccessStatusCode;
        }

        public async Task<TModel> GetMovie(string title, string year)
        {
            string ressource = $"?s={title}&r=json&type=movie&y={year}&page=1";
            var result = await HttpClient.PostAsJsonAsync(Uri, ressource);
            var movieStrg = await result.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<TDto>(movieStrg);
            return Mapper.Map<TModel>(movie);
        }
    }
}