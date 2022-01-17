using Newtonsoft.Json;
using ReserveTaPlace.DTOS;
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
        public async Task<List<Movie>> GetMovie(string title, string year)
        {
            var movies = await SearchMovie(title, year);
            if (movies.Count==0)
            {
                return movies;
            }
            var partialMovie = movies[0];
            Movie completeMovie;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?&r=json&i={partialMovie.ImdbID}"),
                Headers =
                {
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                    { "x-rapidapi-key", "6be4c3adaemsh1b7bf45019b2f71p1a3972jsnebc833006f22" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();

                }
                catch (HttpRequestException e)
                {

                    Console.WriteLine($"{e.Message}");
                }
                    var body = await response.Content.ReadAsStringAsync();
                    completeMovie = JsonConvert.DeserializeObject<Movie>(body);
            }
            movies.Add(completeMovie);
            return movies;
        }
        private async Task<List<Movie>> SearchMovie(string title, string year)
        {
            List<Movie> movies = new List<Movie>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={title}&r=json&type=movie&y={year}&page=1"),
                Headers =
                {
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                    {  "x-rapidapi-key", "6be4c3adaemsh1b7bf45019b2f71p1a3972jsnebc833006f22" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException e )
                {

                    Console.WriteLine($"{e.Message}");
                }
                
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ImdbSearch>(body);
                foreach (var item in result.ImdbMovies)
                {
                    var movie = new Movie(item.Title, item.ImdbID);
                    movies.Add(movie);
                }
            }
            return movies;
        }
    }

}
