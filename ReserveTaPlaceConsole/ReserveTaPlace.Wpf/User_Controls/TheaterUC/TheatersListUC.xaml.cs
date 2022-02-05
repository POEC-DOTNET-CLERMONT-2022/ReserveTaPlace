using ReserveTaPlace.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls.TheaterUC
{
    /// <summary>
    /// Logique d'interaction pour TheatersListUC.xaml
    /// </summary>
    public partial class TheatersListUC : UserControl , INotifyPropertyChanged
    {
        private static readonly DependencyProperty _theatersProperty = DependencyProperty.Register("Theaters", typeof(ObservableCollection<TheaterModel>), typeof(TheatersListUC));
        private ObservableCollection<TheaterModel> _theaters;
        public TheatersListUC()
        {
            InitializeComponent();
        }
        public ObservableCollection<TheaterModel> Theaters
        {
            get { return GetValue(_theatersProperty) as ObservableCollection<TheaterModel>; }
            set
            {
                if(_theaters != value) SetValue(_theatersProperty, value);
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
