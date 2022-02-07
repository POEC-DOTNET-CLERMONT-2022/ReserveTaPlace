using MaterialDesignThemes.Wpf;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
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
        private static readonly DependencyProperty _sessionViewModelProperty = DependencyProperty.Register("SessionViewModel", typeof(SessionViewModel), typeof(PutMovieOnScreenUC));
        private SessionViewModel _sessionViewModel;
        public SessionViewModel SessionViewModel
        {
            get { return GetValue(_sessionViewModelProperty) as SessionViewModel; }
            set
            {
                if (_sessionViewModel != value)
                {
                    SetValue(_sessionViewModelProperty, value);
                }
            }
        }
        public PutMovieOnScreenUC()
        {
            InitializeComponent();
            DataContext = SessionViewModel;
        }
    }
}
