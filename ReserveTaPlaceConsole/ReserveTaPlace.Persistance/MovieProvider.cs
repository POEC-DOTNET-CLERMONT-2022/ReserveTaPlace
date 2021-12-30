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
        public async Task<Movie> GetMovie(string movie)
        {

            var client = new HttpClient(); 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={movie}&r=json&page=1"),
                Headers =
                {
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                    {  "x-rapidapi-key", "" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                //var movie = await response.Content.
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                Console.ReadLine();
            }
            var mov = new Movie("dune");
            return mov;
        }
    }
}
