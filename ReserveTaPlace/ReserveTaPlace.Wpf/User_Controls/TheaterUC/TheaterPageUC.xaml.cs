using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.Models.WPFModels.StateManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            TheaterViewModel.Rooms = new ObservableCollection<RoomModel>();
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
            TheaterDetails.TheaterViewModel = TheaterViewModel;
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
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 50; i++)
            {
                await _seatDataManager.Add(new SeatModel("A", i.ToString()));
                await _seatDataManager.Add(new SeatModel("B", i.ToString()));
                await _seatDataManager.Add(new SeatModel("C", i.ToString()));
                await _seatDataManager.Add(new SeatModel("D", i.ToString()));
                await _seatDataManager.Add(new SeatModel("E", i.ToString()));
                await _seatDataManager.Add(new SeatModel("F", i.ToString()));
                await _seatDataManager.Add(new SeatModel("G", i.ToString()));
                await _seatDataManager.Add(new SeatModel("H", i.ToString()));
                await _seatDataManager.Add(new SeatModel("I", i.ToString()));
                await _seatDataManager.Add(new SeatModel("J", i.ToString()));
                await _seatDataManager.Add(new SeatModel("K", i.ToString()));
                await _seatDataManager.Add(new SeatModel("L", i.ToString()));
                await _seatDataManager.Add(new SeatModel("M", i.ToString()));
                await _seatDataManager.Add(new SeatModel("N", i.ToString()));
                await _seatDataManager.Add(new SeatModel("O", i.ToString()));
                await _seatDataManager.Add(new SeatModel("P", i.ToString()));
                await _seatDataManager.Add(new SeatModel("Q", i.ToString()));
            }

        }

        private async void AddRoom_AddRoom(object sender, System.EventArgs e)
        {
            var rows = AddRoomUC.LBRowSeat.Items.Cast<RowModel>().ToList();
            var roomSeats = new List<SeatModel>();
            foreach (var row in rows) 
            {
                var seats = await _seatDataManager.GetSeats(row);
                roomSeats.AddRange(seats);
            }
            var roomToAdd = new RoomModel(AddRoomUC.TBRoomName.Text, AddRoomUC.TBRoomNumber.Text, AddRoomUC.CBFormatList.SelectedItem as FormatModel,roomSeats);
            var rooms = new List<RoomModel>();
            rooms.Add(roomToAdd);
            TheaterViewModel.Rooms.Add(roomToAdd);
            AddTheater.LBRooms.ItemsSource = TheaterViewModel.Rooms;
        }

        private async void AddTheater_CreateTheater(object sender, System.EventArgs e)
        {
            if (!String.IsNullOrEmpty(AddTheater.TBTheaterCity.Text)
                && !String.IsNullOrEmpty(AddTheater.TBTheaterCounty.Text)
                    && !String.IsNullOrEmpty(AddTheater.TBTheaterName.Text)
                    && !String.IsNullOrEmpty(AddTheater.TBTheaterPostalCode.Text)
                    && AddTheater.LBRooms.Items!=null)
            {
                var adress = new AddressModel(AddTheater.TBTheaterAddress1.Text, AddTheater.TBTheaterAddress2.Text, AddTheater.TBTheaterStreet.Text,
                    AddTheater.TBTheaterCity.Text, AddTheater.TBTheaterPostalCode.Text, AddTheater.TBTheaterNumber.Text, AddTheater.TBTheaterCounty.Text);
                var theater = new TheaterModel(AddTheater.TBTheaterName.Text, adress, TheaterViewModel.Rooms.ToList());
                await _theaterDataManager.AddTheater(theater);
            }
        }
    }
}
