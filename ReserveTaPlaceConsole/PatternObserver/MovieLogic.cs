using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    public class MovieLogic : ISubject
    {
        private readonly IMovie _movie;
        private List<IObserver> _observers = new List<IObserver>();

        public Movie AddNewMovie(Movie movie)
        {
            Notify(movie);
            return _movie.AddNewMovie(movie);
        }

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject : Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify(Movie movie)
        {
            Console.WriteLine($"Le film {movie.Title} a été ajouté !!");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
