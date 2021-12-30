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
        public List<Movie> LoadMovies()
        {
            var movies = new List<Movie>();
            using (FileStream fs = File.OpenRead(@"movieList.txt"))
            {
                movies = JsonConvert.DeserializeObject<List<Movie>>(@"movieList.txt");
                fs.Close();
            }
            return movies;
        }

        public void SaveMovies(List<Movie> movieList)
        {
            using(FileStream fs = File.Create(@"movieList.txt"))
            {
                var jsonString = JsonConvert.SerializeObject(movieList);
                File.WriteAllText(@"movieList.txt", jsonString);
                fs.Close();
            }
        }
    }
}
