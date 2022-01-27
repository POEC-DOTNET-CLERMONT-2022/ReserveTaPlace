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
        public MainMenuUC()
        {
            InitializeComponent();
        }
        private void ListUserBTN_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new UserWindow();
            userWindow.Show();
        }

        private void ListmovieBTN_Click(object sender, RoutedEventArgs e)
        {
            var movieWindow = new MovieWindow();
            movieWindow.Show();
        }
    }
}
