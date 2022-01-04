using ReserveTaPlace.Logic;
using ReserveTaPlace.Wpf.User_Controls;
using ServiceReference;
using ServiceReference;
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

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserLogic userLogic = new UserLogic();
        MovieLogic movieLogic = new MovieLogic();
        public MainWindow()
        {
            InitializeComponent();
            //App.InitializedUserList();
            //App.InitializedMoviesList();
            //UserLV.ItemsSource = userLogic.GetUsers();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            ResultTB.Text = userLogic.GetUser(LoginTB.Text, PasswordTB.Text);
        }

        private void ViewListBTN_Click(object sender, RoutedEventArgs e)
        {
            LoginGrid.Visibility = Visibility.Hidden;
            UserListUC.Visibility = Visibility.Visible;
        }

        private void listmovieBTN_Click(object sender, RoutedEventArgs e)
        {
            var client = new MovieServiceClient();
            //var listMovie = await client.GetAllMoviesAsync();
            var test = client.GetData(50);
            var listMovie2 = client.GetAllMovies();
            var listMovie3 = movieLogic.GetAllMovies();
            client.Close();

        }
    }
}
