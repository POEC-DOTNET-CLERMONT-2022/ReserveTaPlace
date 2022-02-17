using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.Models.WPFModels.StateManager;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls.TheaterUC
{
    /// <summary>
    /// Logique d'interaction pour TheaterPageUC.xaml
    /// </summary>
    public partial class TheaterPageUC : UserControl
    {
        public TheaterViewModel TheaterViewModel { get; set; }
        private readonly IDataManager<TheaterModel, TheaterDto> _theaterDataManager;
        public TheaterPageUC()
        {
            InitializeComponent();
            TheaterViewModel = new TheaterViewModel();
            TheaterViewModel.StateManager = new TheaterPageStateManager(TheaterPageState.TheaterListView);
            _theaterDataManager = ((App)Application.Current).TheaterDataManager;
            DataContext = TheaterViewModel;
            
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var theaters = await _theaterDataManager.GetAll();
            TheaterViewModel.Theaters = new ObservableCollection<TheaterModel>(theaters);
            TheaterList.Theaters = TheaterViewModel.Theaters;
            TheaterViewModel.StateManager.Set(TheaterPageState.TheaterListView);
        }

        private void TheaterListUC_SelectionChanged(object sender, System.EventArgs e)
        {
            TheaterViewModel.CurrentTheater = TheaterList.LVTheaters.SelectedItem as TheaterModel;
            TheaterDetails.DataContext = TheaterViewModel.CurrentTheater;
        }
    }
}
