﻿using System;
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

        private MovieModel _currentMovie;
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
