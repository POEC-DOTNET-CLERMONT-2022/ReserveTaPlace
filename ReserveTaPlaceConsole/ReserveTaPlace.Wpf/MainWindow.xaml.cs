using ReserveTaPlace.Logic;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserLogic _userLogic;
        private MovieLogic _movieLogic;
        public MainWindow()
        {
            _userLogic = ((App)Application.Current).UserLogic;
            _movieLogic = ((App)Application.Current).MovieLogic;
            InitializeComponent();
            App.InitializedUserList();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            ResultTB.Text = _userLogic.GetUser(LoginTB.Text, PasswordTB.Text);
        }

        private void ViewListBTN_Click(object sender, RoutedEventArgs e)
        {
            LoginGrid.Visibility = Visibility.Hidden;
            //UserListUC.Visibility = Visibility.Visible;
        }

        private async void listmovieBTN_Click(object sender, RoutedEventArgs e)
        {
            var movieWindow = new MovieWindow();
            movieWindow.Show();
            //var listMovie3 = await _movieLogic.GetAll();
        }

    }
}
