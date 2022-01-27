using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.Wpf.User_Controls;
using ReserveTaPlace.Wpf.Utils;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGenericLogic<User> _userLogic = new GenericLogic<User>();
        private IMovieLogic _movieLogic;
        private INavigator _navigator;
        public MainWindow()
        {
            InitializeComponent();
            _userLogic = ((App)Application.Current).UserLogic;
            _movieLogic = ((App)Application.Current).MovieLogic;
            _navigator = ((App)Application.Current).Navigator;
            _navigator.NavigateTo(typeof(LoginPageUC));
        }

    }
}
