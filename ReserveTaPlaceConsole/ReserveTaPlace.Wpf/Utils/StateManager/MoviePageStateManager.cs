using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Wpf.Utils.StateManager
{
    public class MoviePageStateManager
    {
        public MoviePageStateManager(MoviePageState state)
        {
            Set(state);
        }
        public bool IsAddMovieVisible { get; set; }
        public bool IsMoviesListVisible { get; set; }
        public bool IsPutOnScreenVisible { get; set; }
        public bool IsMoviesPagerVisible { get; set; }

        void Set(MoviePageState state)
        {
            switch (state)
            {
                case MoviePageState.MoviePageView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = false;
                    IsAddMovieVisible = false;
                    IsMoviesPagerVisible = false;
                    break;
                case MoviePageState.AddMovieView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = false;
                    IsMoviesPagerVisible = false;
                    IsAddMovieVisible = true;
                    break;
                case MoviePageState.MovieListView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = true;
                    IsMoviesPagerVisible = true;
                    IsAddMovieVisible = false;
                    break;
                case MoviePageState.PutOnScreenView:
                    IsPutOnScreenVisible = true;
                    IsMoviesListVisible = false;
                    IsAddMovieVisible = false;
                    IsMoviesPagerVisible =false;
                    break;
                default:
                    break;
            }
        }
    }
}
