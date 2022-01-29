using ReserveTaPlace.Wpf.Utils;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for LoginPageUC.xaml
    /// </summary>
    public partial class LoginPageUC : UserControl
    {
        public INavigator Navigator { get; set; }

        public LoginPageUC()
        {
            InitializeComponent();
            Navigator = ((App)Application.Current).Navigator;

        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(HomePage));
        }
    }
}
