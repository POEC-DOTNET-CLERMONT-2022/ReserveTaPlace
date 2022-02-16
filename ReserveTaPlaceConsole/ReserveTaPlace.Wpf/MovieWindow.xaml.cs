﻿using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.MovieDataBaseService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    //TODO : à supprimer
    public partial class MovieWindow : Window
    {
        //TODO : à supprimer
        //private IMovieLogic _movieLogic;
        //private IMovieProvider _movieProvider;
        private readonly IMapper _mapper;
        private ListMovies _listMovie;
        private readonly IDataManager<MovieModel, MovieDto> _movieDataManager;
        private IDataManager<MovieModel, MovieDto> _movieProviderDataManager;

        public MovieWindow()
        {
            //TODO : à supprimer
            //_movieProvider = ((App)Application.Current).MovieProvider;
            //_movieLogic = ((App)Application.Current).MovieLogic;
            _listMovie = new ListMovies();
            _mapper = ((App)Application.Current).Mapper;
            InitializeComponent();
            DataContext = _listMovie;
            _movieDataManager = ((App)Application.Current).MovieDataManager;
            _movieProviderDataManager = ((App)Application.Current).MovieProviderDataManager;


        }
        public async void LoadMovies()
        {
            //TODO : à mettre dans un service /manager
            var movies = await _movieDataManager.GetAll();
            var moviesModel = _mapper.Map<IEnumerable<MovieModel>>(movies);
            _listMovie.Movies = new ObservableCollection<MovieModel>(moviesModel);
        }

        private async void Button_AddMovie(object sender, RoutedEventArgs e)
        {
            var movieName = TBMovieToAddName.Text;
            var movieYear = TBMovieToAddYear.Text;
            var movie = await _movieProviderDataManager.GetMovie(movieName, movieYear);
            _listMovie.Movies.Add(movie);
            var result = await _movieDataManager.Add(movie);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMovies();
        }
    }
}
