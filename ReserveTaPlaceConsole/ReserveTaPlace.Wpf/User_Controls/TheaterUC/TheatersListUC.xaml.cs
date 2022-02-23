using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.Models.WPFModels.StateManager;
using System;
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
        public TheaterViewModel TheaterViewModel { get; set; }
        public TheaterModel SelectedTheater { get { return LVTheaters.SelectedItem as TheaterModel; } }
        public TheatersListUC()
        {
            InitializeComponent();
            TheaterViewModel = new TheaterViewModel();
            TheaterViewModel.StateManager = new TheaterPageStateManager(TheaterPageState.AddTheaterView);
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks on a theater in the list")]
        public event EventHandler SelectionChanged;
        public ObservableCollection<TheaterModel> Theaters
        {
            get { return GetValue(_theatersProperty) as ObservableCollection<TheaterModel>; }
            set
            {
                if(_theaters != value) SetValue(_theatersProperty, value);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void LVTheaters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.SelectionChanged != null)
                this.SelectionChanged(this, e);
        }
        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTNUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks on button createTheater")]
        public event EventHandler CreateTheater;
        private void BTNCreateTheater_Click(object sender, RoutedEventArgs e)
        {
            if (this.CreateTheater != null)
                this.CreateTheater(this, e);
        }
    }
}
