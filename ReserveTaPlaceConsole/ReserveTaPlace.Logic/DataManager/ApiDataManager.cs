﻿using AutoMapper;
using Newtonsoft.Json;
using ReserveTaPlace.Models.WPFModels;
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
            var map = Mapper.Map<IEnumerable<TModel>>(result);
            return map;
        }

        public async Task<bool> Add(TModel model)
        {
            var dto = Mapper.Map<TDto>(model);
            var result = await HttpClient.PostAsJsonAsync(Uri, dto);
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

        public async Task<TModel> GetMovieByNameAndYear(string title, string year)
        {
            var ressourceList = new List<string>() { title,year};
            var _uri = new Uri(Uri + "/GetMovieByNameAndYear");
            var result = await HttpClient.PostAsJsonAsync<List<string>>(_uri, ressourceList);
            var movieStrg = await result.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<TDto>(movieStrg);
            return Mapper.Map<TModel>(movie);
        }

        public async Task<PaginatedList<TModel>> GetAllPaginated(int page, int pageSize)
        {
            var ressourceList = new List<int>() { page, pageSize };
            var _uri = new Uri(Uri + "/GetAllPaginated");
            var result = await HttpClient.PostAsJsonAsync<List<int>>(_uri, ressourceList);
            var moviesStrg = await result.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<PaginatedList<TDto>>(moviesStrg);
            return Mapper.Map<PaginatedList<TModel>>(movies);
        }

        public async Task<bool> DeleteTheaterById(Guid id)
        {
            var response = await HttpClient.DeleteAsync(Uri + $"/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<TModel> GetTheaterById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> GetTheaterByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> UpdateTheater(TModel model)
        {
            var response = await HttpClient.PutAsJsonAsync(Uri, model);
            response.EnsureSuccessStatusCode();
            var theaterString = await response.Content.ReadAsStringAsync();
            var theater = JsonConvert.DeserializeObject<TDto>(theaterString);
            return Mapper.Map<TModel>(theater);

        }
    }
}
