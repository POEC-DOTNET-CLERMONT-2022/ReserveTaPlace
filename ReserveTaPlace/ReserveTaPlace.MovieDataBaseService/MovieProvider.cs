using Newtonsoft.Json;
using ReserveTaPlace.DTOS;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReserveTaPlace.MovieDataBaseService
{
    public class MovieProvider : IMovieProvider
    {
        public async Task<List<MovieDto>> GetMovie(string title, string year)
        {
            var movies = await SearchMovie(title, year);
            if (movies.Count == 0)
            {
                return movies;
            }
            var partialMovie = movies[0];
            MovieDto completeMovie = new MovieDto();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?&r=json&i={partialMovie.ImdbId}"),
                Headers =
                {
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                    { "x-rapidapi-key", "" },
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
                completeMovie = JsonConvert.DeserializeObject<MovieDto>(body);
            }
            movies.Add(completeMovie);
            List<MovieDto> moviesDto = new List<MovieDto>();
            moviesDto.Add(completeMovie);
            return moviesDto;
        }
        private async Task<List<MovieDto>> SearchMovie(string title, string year)
        {
            List<MovieDto> movies = new List<MovieDto>();
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
                catch (HttpRequestException e)
                {

                    Console.WriteLine($"{e.Message}");
                }

                var body = await response.Content.ReadAsStringAsync();
                List<MovieDto> test = JsonConvert.DeserializeObject<List<MovieDto>>(body);
                var result = JsonConvert.DeserializeObject<ImdbSearch>(body);
                foreach (var item in result.ImdbMovies)
                {
                    var movie = new MovieDto() { 
                        ImdbId=item.ImdbId,
                        Plot=item.Plot,
                        Title=item.Title,
                        Poster=item.Poster,
                        Released=item.Released,
                        Runtime=item.Runtime
                    };
                    movies.Add(movie);
                }
            }
            return movies;
        }
    }

}
