using MaterialDesignThemes.Wpf;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PutMovieOnScreenUC.xaml
    /// </summary>
    public partial class PutMovieOnScreenUC : UserControl
    {
        private static readonly DependencyProperty _currentMovieProperty = DependencyProperty.Register("CurrentMovie", typeof(MovieModel), typeof(PutMovieOnScreenUC));
        private MovieModel _currentMovie;
        public PutMovieOnScreenUC()
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
    }
}
