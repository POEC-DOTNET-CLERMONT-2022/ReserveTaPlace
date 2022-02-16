using Newtonsoft.Json;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using System.Net.Http.Headers;
using System.Text;

namespace ReserveTaPlace.Logic
{

    public class MovieLogic : IMovieLogic
    {
        //TODO : pas besoin ? 
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

        public async Task Add(MovieDto movieDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7091/api/movie");
            //request.Headers.Add("Accept", "application/json");
            var jsonMovieDto = JsonConvert.SerializeObject(movieDto);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(jsonMovieDto, Encoding.UTF8, "application/json");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = new HttpClient();
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

            }
        }
    }
}
