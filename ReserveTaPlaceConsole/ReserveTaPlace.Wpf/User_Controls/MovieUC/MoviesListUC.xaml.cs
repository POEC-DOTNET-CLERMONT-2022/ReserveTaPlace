using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
