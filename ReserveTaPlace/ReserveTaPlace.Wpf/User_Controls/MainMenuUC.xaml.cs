using ReserveTaPlace.Wpf.User_Controls.MovieUC;
using ReserveTaPlace.Wpf.User_Controls.TheaterUC;
using ReserveTaPlace.Wpf.Utils;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for MainMenuUC.xaml
    /// </summary>
    public partial class MainMenuUC : UserControl
    {
        public INavigator Navigator { get; set; }

        public MainMenuUC()
        {
            InitializeComponent();
            Navigator = ((App)Application.Current).Navigator;

        }

        private void ListmovieBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(MoviePageUC));
        }

        private void ListUserBTNBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(UserPageUC));
        }

        private void ListtheaterBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(TheaterPageUC));
        }
    }
}
