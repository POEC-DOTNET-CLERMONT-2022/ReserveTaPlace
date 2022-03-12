using ReserveTaPlace.Models.WPFModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls.TheaterUC
{
    /// <summary>
    /// Logique d'interaction pour TheaterDetailsUC.xaml
    /// </summary>
    public partial class TheaterDetailsUC : UserControl , INotifyPropertyChanged
    {
        private static readonly DependencyProperty _theaterViewModelProperty = DependencyProperty.Register("TheaterViewModel", typeof(TheaterViewModel), typeof(TheaterDetailsUC));
        private TheaterViewModel _theaterViewModel;
        public TheaterDetailsUC()
        {
            InitializeComponent();
        }

        public TheaterViewModel TheaterViewModel
        {
            get { return GetValue(_theaterViewModelProperty) as TheaterViewModel; }
            set
            {
                if(_theaterViewModel != value)
                {
                    SetValue(_theaterViewModelProperty, value);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void BTNDeleteRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTNUpdateRoom_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
