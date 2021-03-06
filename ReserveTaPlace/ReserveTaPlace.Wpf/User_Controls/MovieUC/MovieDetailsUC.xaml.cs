using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MovieDetailsUC.xaml
    /// </summary>
    public partial class MovieDetailsUC : UserControl, INotifyPropertyChanged
    {
        private static readonly DependencyProperty _currentMovieProperty = DependencyProperty.Register("CurrentMovie", typeof(MovieModel), typeof(MovieDetailsUC)); 
        private MovieModel _currentMovie;
        public MovieDetailsUC()
        {
            InitializeComponent();
        }
        public MovieModel CurrentMovie
        {
            get { return GetValue(_currentMovieProperty) as MovieModel; }
            set
            {
                if (_currentMovie != value)
                {

                    SetValue(_currentMovieProperty, value);
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
