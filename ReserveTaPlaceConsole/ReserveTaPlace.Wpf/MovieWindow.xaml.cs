using ReserveTaPlace.Logic;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    public partial class MovieWindow : Window
    {
        private MovieLogic _movieLogic;

        public MovieWindow()
        {
            _movieLogic = ((App)Application.Current).MovieLogic;
            InitializeComponent();

        }
    }
}
