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
        public INavigator Navigator { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _userLogic = ((App)Application.Current).UserLogic;
            _movieLogic = ((App)Application.Current).MovieLogic;
            Navigator = ((App)Application.Current).Navigator;
            Navigator.NavigateTo(typeof(LoginPageUC));
        }

    }
}
