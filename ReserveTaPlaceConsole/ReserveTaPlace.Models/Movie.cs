﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class Movie
    {
        private int _id;
        private string _imdbID;
        private string _title;
        private string _plot;
        private string _country;
        private string _castStartDate;
        private string _castEndDate;
        private string _releaseDate;
        private string _runtime;
        private bool _isMovieOnDisplay;
        [JsonConstructor]
        public Movie(int id, string title)
        {
            _id = id ;
            _title = title;
            _isMovieOnDisplay = false;
        }
        public Movie(string title,string imdbID)
        {
            _title = title;
            _imdbID = imdbID;
            //_description = description;
            //_castStartDate = castStartDate;
            //_castEndDate = castEndDate;
            //_releaseDate = releaseDate;
            //_duration = duration;
            _isMovieOnDisplay = false;
        }
        
        public int Id { get { return _id; } }
        public string ImdbID{ get { return _imdbID; } set { _imdbID = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Country{get { return _country; } set { _country = value; } }
        public string Plot { get { return _plot; } set { _plot = value; } }
        public string CastStartDate { get { return _castStartDate; } set { _castStartDate = value; } }
        public string CastEndDate { get { return _castEndDate; } set { _castEndDate = value; } }
        public string ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; } }
        public string Runtime { get { return _runtime; } set { _runtime = value; } }
        public bool IsMovieOnDisplay
        {
            get { return _isMovieOnDisplay; }
            set { _isMovieOnDisplay = value; }
        }


    }
}
