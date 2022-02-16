using ReserveTaPlace.Models.WPFModels.StateManager;
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
        private ObservableCollection<MovieModel> _movies;
        private MoviePageStateManager _stateManager;
        private MovieModel _currentMovie;

        private PaginatedList<MovieModel> _paginatedMovies;

        public PaginatedList<MovieModel> PaginatedMovies
        {
            get { return _paginatedMovies; }
            set { _paginatedMovies = value; OnNotifyPropertyChanged(); }
        }
        public MoviePageStateManager StateManager
        {
            get { return _stateManager; }
            set { _stateManager = value; OnNotifyPropertyChanged(); }
        }

        public MovieModel FoundMovie { get; set; }
        public MovieModel CurrentMovie
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
        public ObservableCollection<MovieModel> Movies
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
