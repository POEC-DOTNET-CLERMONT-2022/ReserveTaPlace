using Newtonsoft.Json;
using ReserveTaPlace.Models;

namespace ReserveTaPlace.Persistance.Functions
{
    public class MovieFunctions : IPersistance
    {
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var jsonMovies = await File.ReadAllTextAsync(@"movieList.txt");
            var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(jsonMovies);
            return movies;
        }

        public async Task SaveMovies(IEnumerable<Movie> movieList)
        {
            //using(FileStream fs = File.Create(@"movieList.txt"))
            //{

            //    fs.Close();
            //}
            var jsonString = JsonConvert.SerializeObject(movieList);
            await File.WriteAllTextAsync(@"movieList.txt", jsonString);

        }

    }
}
