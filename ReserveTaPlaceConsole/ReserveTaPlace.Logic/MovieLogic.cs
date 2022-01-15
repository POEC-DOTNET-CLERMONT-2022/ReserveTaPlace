using Newtonsoft.Json;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;

namespace ReserveTaPlace.Logic
{

    public class MovieLogic : IMovieLogic
    {
        private IMovie _movie;
        public MovieLogic()
        {
            _movie = new MovieFunctions();
        }
        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = new List<Movie>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:7091/api/movie/all"),
                Headers =
            {
            },
            };
            using (var res = await client.SendAsync(request))
            {
                try
                {
                    res.EnsureSuccessStatusCode();

                }
                catch (HttpRequestException e)
                {

                    Console.WriteLine($"{e.Message}");
                }
                var body = await res.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<List<Movie>>(body);
            }
            //return movies;
            HttpResponseMessage response = await client.GetAsync("https://localhost:7091/api/movie/all");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }
            return movies;

        }
    }
}
