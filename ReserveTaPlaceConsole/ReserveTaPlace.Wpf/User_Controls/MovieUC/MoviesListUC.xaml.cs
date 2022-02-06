using ReserveTaPlace.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls.MovieUC
{
    /// <summary>
    /// Interaction logic for MoviesListUC.xaml
    /// </summary>
    public partial class MoviesListUC : UserControl
    {
        private static readonly DependencyProperty _moviesProperty = DependencyProperty.Register("Movies", typeof(ObservableCollection<MovieModel>), typeof(MoviesListUC));
        private ObservableCollection<MovieModel> _movies;
        public MovieModel SelectedMovie { get { return LBMovies.SelectedItem as MovieModel; } }
        public MoviesListUC()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks on a movie in the list")]
        public event EventHandler SelectionChanged;
        public ObservableCollection<MovieModel> Movies
        {
            get { return GetValue(_moviesProperty) as ObservableCollection<MovieModel>; }
            set
            {
                if (_movies != value)
                {
                    SetValue(_moviesProperty, value);
                }
            }
        }

        private void LBMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.SelectionChanged != null)
                this.SelectionChanged(this, e);
        }
    }
}
