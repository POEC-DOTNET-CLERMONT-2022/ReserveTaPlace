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
        private readonly IDataManager<SeatModel, SeatDto> _seatDataManager;

        public TheaterPageUC()
        {
            InitializeComponent();
            TheaterViewModel = new TheaterViewModel();
            TheaterViewModel.StateManager = new TheaterPageStateManager(TheaterPageState.TheaterListView);
            _theaterDataManager = ((App)Application.Current).TheaterDataManager;
            _seatDataManager = ((App)Application.Current).SeatDataManager;
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

        private void TheaterList_CreateTheater(object sender, System.EventArgs e)
        {
            TheaterViewModel.StateManager.Set(TheaterPageState.AddTheaterView);
        }

        private void AddTheater_CreateRoom(object sender, System.EventArgs e)
        {
            TheaterViewModel.StateManager.Set(TheaterPageState.AddRoomView);
        }
        //Todo facto to layer
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 26; i++)
            {
                _seatDataManager.Add(new SeatModel("A", i.ToString()));
                _seatDataManager.Add(new SeatModel("B", i.ToString()));
                _seatDataManager.Add(new SeatModel("C", i.ToString()));
                _seatDataManager.Add(new SeatModel("D", i.ToString()));
                _seatDataManager.Add(new SeatModel("E", i.ToString()));
                _seatDataManager.Add(new SeatModel("F", i.ToString()));
                _seatDataManager.Add(new SeatModel("G", i.ToString()));
                _seatDataManager.Add(new SeatModel("H", i.ToString()));
                _seatDataManager.Add(new SeatModel("I", i.ToString()));
                _seatDataManager.Add(new SeatModel("J", i.ToString()));

            }

        }

        private void AddRoom_AddRoom(object sender, System.EventArgs e)
        {
            //var roomToAdd = new RoomModel(AddRoomUC.TBRoomName.Text, AddRoomUC.TBRoomNumber.Text, AddRoomUC.CBFormatList.SelectedItem);
        }
    }
}
