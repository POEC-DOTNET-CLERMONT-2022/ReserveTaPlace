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
    /// Interaction logic for AddMovieUC.xaml
    /// </summary>
    public partial class AddMovieUC : UserControl
    {
        private readonly IMapper _mapper;
        private ListMovies _listMovie;
        private readonly IDataManager<MovieModel, MovieDto> _movieDataManager;
        private IDataManager<MovieModel, MovieDto> _movieProviderDataManager;
        public AddMovieUC()
        {
            InitializeComponent();
            _listMovie = new ListMovies();
            _mapper = ((App)Application.Current).Mapper;
            DataContext = _listMovie;
            _movieDataManager = ((App)Application.Current).MovieDataManager;
            _movieProviderDataManager = ((App)Application.Current).MovieProviderDataManager;
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks previous page's icon")]
        public event EventHandler GoPreviousPage;
        private async void Button_AddMovie(object sender, RoutedEventArgs e)
        {
            var result = await _movieDataManager.Add(_listMovie.CurrentMovie);
        }

        private async void Button_SearchMovie(object sender, RoutedEventArgs e)
        {
            SPMovieFound.Visibility = Visibility.Collapsed;
            var movieName = TBMovieToAddName.Text;
            var movieYear = TBMovieToAddYear.Text;
            if (await _movieDataManager.GetMovieByNameAndYear(movieName, movieYear)!=null)
            {
                _listMovie.FoundMovie = await _movieDataManager.GetMovieByNameAndYear(movieName, movieYear);
                IMGmovieFound.DataContext = _listMovie;
                SPMovieFound.Visibility = Visibility.Visible;

            }

                var movie = await _movieProviderDataManager.GetMovie(movieName, movieYear);
                MovieDetailsUC.CurrentMovie = movie;
                _listMovie.CurrentMovie = movie;
                SPImbdResult.Visibility = Visibility.Visible;
        }

        private void Button_Return(object sender, RoutedEventArgs e)
        {
            if (this.GoPreviousPage != null)
                this.GoPreviousPage(this, e);
        }

    }
}
