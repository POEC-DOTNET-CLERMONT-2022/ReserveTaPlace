﻿using Newtonsoft.Json;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;

namespace ReserveTaPlace.Logic
{

    public class MovieLogic : IMovieLogic
    {
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var movies = new List<MovieDto>();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7091/api/movie");
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            ;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<List<MovieDto>>(jsonString);
                }
            }
            return movies;
        }

        public async Task<MovieDto> Add(MovieDto movieDto)
        {
            var movie = new MovieDto();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7091/api/movie");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(JsonConvert.SerializeObject(movieDto));
            var client = new HttpClient();
            ;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<MovieDto>(jsonString);
                }
            }
            return movie;
        }
    }
}
