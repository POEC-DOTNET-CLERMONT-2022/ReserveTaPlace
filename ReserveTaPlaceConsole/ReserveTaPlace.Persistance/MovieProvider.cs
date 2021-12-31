using Newtonsoft.Json;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Persistance
{
    public class MovieProvider : IMovieProvider
    {
        public async Task<List<Movie>> GetMovie(string movie)
        {
            List<Movie> movies = new List<Movie>();
            var client = new HttpClient(); 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={movie}&r=json&page=1"),
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
                var result = JsonConvert.DeserializeObject<dynamic>(body);
                var test = result.Search;
                test = (List)test;
                foreach (var item in test)
                {
                    var teestt = item;
                    var mov = new Movie(item[0]);
                    movies.Add(mov);
                }
                Console.WriteLine(movies.Count);
                Console.ReadLine();
            }
            return movies;
        }
    }
}
