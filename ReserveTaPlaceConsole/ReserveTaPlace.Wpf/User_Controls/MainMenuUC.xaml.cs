using ReserveTaPlace.Wpf.User_Controls.MovieUC;
using ReserveTaPlace.Wpf.Utils;
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
    }
}
