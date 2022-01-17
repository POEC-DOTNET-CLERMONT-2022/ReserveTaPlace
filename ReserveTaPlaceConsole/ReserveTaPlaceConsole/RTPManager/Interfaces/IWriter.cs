using ReserveTaPlace.Models;

namespace ReserveTaPlace.RTPManager.Interfaces
{
    public interface IWriter
    {
        public void DisplayMovie(Movie movie);
        public void DisplayMovies(IEnumerable<Movie> movies);
        public void DisplayOnDisplayMovies(IEnumerable<Movie> movies);
    }
}
