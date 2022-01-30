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

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for MoviesListUC.xaml
    /// </summary>
    public partial class MoviesListUC : UserControl, INotifyPropertyChanged
    {
        private static readonly DependencyProperty _moviesProperty = DependencyProperty.Register("Movies", typeof(ObservableCollection<MovieModel>), typeof(MoviesListUC));
        private ObservableCollection<MovieModel> _movies;

        public MoviesListUC()
        {
            InitializeComponent();
        }
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
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnNotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            //}
        }
    }
}
