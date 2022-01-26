using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels
{
    public class ListMovies : ObservableObject
    {
        private ObservableCollection<Movie> _movies;

        private Movie _currentMovie;

        public Movie CurrentMovie
        {
            get { return _currentMovie; }
            set
            {
                if (_currentMovie != value)
                {
                    _currentMovie = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
