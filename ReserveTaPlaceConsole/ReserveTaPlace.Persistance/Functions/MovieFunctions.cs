using Newtonsoft.Json;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Persistance.Functions
{
    public class MovieFunctions : IPersistance
    {
        public async Task<List<Movie>> LoadMovies()
        {
            var jsonMovies = await File.ReadAllTextAsync(@"movieList.txt");
            var movies = JsonConvert.DeserializeObject<List<Movie>>(jsonMovies);
            return movies;
        }

        public void SaveMovies(List<Movie> movieList)
        {
            using(FileStream fs = File.Create(@"movieList.txt"))
            {

                fs.Close();
            }
            var jsonString = JsonConvert.SerializeObject(movieList);
            File.WriteAllText(@"movieList.txt", jsonString);

        }
    }
}
