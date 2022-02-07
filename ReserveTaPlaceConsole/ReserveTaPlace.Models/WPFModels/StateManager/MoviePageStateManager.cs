using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels.StateManager
{
    public class MoviePageStateManager : INotifyPropertyChanged
    {
        private bool _isAddMovieVisible;
        private bool _isMoviesListVisible;
        private bool _isPutOnScreenVisible;
        private bool _isMoviesPagerVisible;
        private bool _isSPSearchVisible;
        private bool _isMovieDetailsVisible;

        public MoviePageStateManager(MoviePageState state)
        {
            Set(state);
        }


        public bool IsAddMovieVisible { get { return _isAddMovieVisible; } set { _isAddMovieVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsMoviesListVisible { get { return _isMoviesListVisible; } set { _isMoviesListVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsPutOnScreenVisible { get { return _isPutOnScreenVisible; } set { _isPutOnScreenVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsMoviesPagerVisible { get { return _isMoviesPagerVisible; } set { _isMoviesPagerVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsSPSearchVisible { get { return _isSPSearchVisible; } set { _isSPSearchVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsMovieDetailsVisible { get { return _isMovieDetailsVisible; } set { _isMovieDetailsVisible = value; OnNotifyPropertyChanged(); } }

        public void Set(MoviePageState state)
        {
            switch (state)
            {
                case MoviePageState.MoviesListView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = true;
                    IsMoviesPagerVisible = true;
                    IsAddMovieVisible = false;
                    IsSPSearchVisible = true;
                    IsMovieDetailsVisible = false;
                    break;
                case MoviePageState.AllOff:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = false;
                    IsMoviesPagerVisible = false;
                    IsAddMovieVisible = false;
                    IsSPSearchVisible = false;
                    IsMovieDetailsVisible = false;
                    break;
                case MoviePageState.AddMovieView:
                    IsPutOnScreenVisible = false;
                    IsMoviesListVisible = false;
                    IsMoviesPagerVisible = false;
                    IsAddMovieVisible = true;
                    IsSPSearchVisible = false;
                    IsMovieDetailsVisible = false;
                    break;
                case MoviePageState.PutOnScreenView:
                    IsPutOnScreenVisible = true;
                    IsMoviesListVisible = true;
                    IsAddMovieVisible = false;
                    IsMoviesPagerVisible =true;
                    IsSPSearchVisible = true;
                    IsMovieDetailsVisible = true;
                    break;
                default:
                    break;
            }
        }
        protected virtual void OnNotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
