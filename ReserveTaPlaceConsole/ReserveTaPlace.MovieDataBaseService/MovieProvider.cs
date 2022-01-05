﻿using Newtonsoft.Json;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.MovieDataBaseService
{
    public class MovieProvider : IMovieProvider
    {
        public async Task<Movie> GetMovie(string title, string year)
        {
            var movies = await SearchMovie(title, year);
            var partialMovie = movies[0];
            Movie completeMovie;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?&r=json&i={partialMovie.Id}"),
                Headers =
                {
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                    { "x-rapidapi-key", "6be4c3adaemsh1b7bf45019b2f71p1a3972jsnebc833006f22" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                completeMovie = JsonConvert.DeserializeObject<Movie>(body);

            }
            return completeMovie;
        }
        private async Task<List<Movie>> SearchMovie(string title, string year)
        {
            List<Movie> movies = new List<Movie>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={title}&r=json&y={year}&page=1"),
                Headers =
                {
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                    {  "x-rapidapi-key", "6be4c3adaemsh1b7bf45019b2f71p1a3972jsnebc833006f22" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ImdbSearch>(body);
                foreach (var item in result.ImdbMovies)
                {
                    var teestt = item;
                    if (item.Type != "series")
                    {
                        var mov = new Movie(item.Title);
                        movies.Add(mov);
                    }

                }
            }
            return movies;
        }
    }

}
