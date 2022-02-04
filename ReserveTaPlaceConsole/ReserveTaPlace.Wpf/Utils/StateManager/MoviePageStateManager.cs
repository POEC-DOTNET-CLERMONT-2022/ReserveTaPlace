using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Wpf.Utils.StateManager
{
    internal class MoviePageStateManager
    {
        private MoviePageStateManager()
        {

        }
        internal bool IsAddMovieVisible { get; set; }
        internal bool IsMoviesListVisible { get; set; }
        internal bool IsPutOnScreenVisible { get; set; }
        void Set(MoviePageState state)
        {
            switch (state)
            {
                case MoviePageState.MoviePageView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = false;
                    IsAddMovieVisible = false;
                    break;
                case MoviePageState.AddMovieView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = false;
                    IsAddMovieVisible = true;
                    break;
                case MoviePageState.MovieListView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = true;
                    IsAddMovieVisible = false;
                    break;
                case MoviePageState.PutOnScreenView:
                    IsPutOnScreenVisible = true;
                    IsMoviesListVisible = false;
                    IsAddMovieVisible = false;
                    break;
                default:
                    break;
            }
        }
    }
}
