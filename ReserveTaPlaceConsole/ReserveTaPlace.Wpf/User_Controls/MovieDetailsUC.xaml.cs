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

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for MovieDetailsUC.xaml
    /// </summary>
    public partial class MovieDetailsUC : UserControl, INotifyPropertyChanged
    {
        private static readonly DependencyProperty _currentMovieProperty = DependencyProperty.Register("CurrentMovie", typeof(Movie), typeof(MovieDetailsUC)); 
        private Movie _currentMovie;
        public MovieDetailsUC()
        {
            InitializeComponent();
        }
        public Movie CurrentMovie
        {
            get { return GetValue(_currentMovieProperty) as Movie; }
            set
            {
                if (_currentMovie != value)
                {

                    SetValue(_currentMovieProperty, value);
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnNotifyPropertyChanged([CallerMemberName] string propertyname =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            //}
        }
    }
}
