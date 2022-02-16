using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls.RoomUC
{
    /// <summary>
    /// Logique d'interaction pour RoomAddUC.xaml
    /// </summary>
    public partial class AddRoomUC : UserControl, INotifyPropertyChanged
    {
        //private static readonly DependencyProperty _roomViewModelProperty = DependencyProperty.Register("RoomViewModel", typeof(RoomViewModel), typeof(AddRoomUC));
        public RoomViewModel RoomViewModel { get; set; }
        private readonly IDataManager<FormatModel, FormatDto> _formatDataManager;
        private readonly IDataManager<SeatModel, SeatDto> _seatDataManager;
        public AddRoomUC()
        {
            InitializeComponent();
            _formatDataManager = ((App)Application.Current).FormatDataManager;
            _seatDataManager = ((App)Application.Current).SeatDataManager;
            RoomViewModel = new RoomViewModel();
        }
        //public RoomViewModel RoomViewModel
        //{
        //    get { return GetValue(_roomViewModelProperty) as RoomViewModel; }
        //    set
        //    {
        //        if (_roomViewModel != value)
        //        {
        //            SetValue(_roomViewModelProperty, value);
        //        }
        //    }
        //}

        public event PropertyChangedEventHandler? PropertyChanged;

        private void BTNAddRoom_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var formats = await _formatDataManager.GetAll();
            var seats = await _seatDataManager.GetAll();
            RoomViewModel.Formats = new ObservableCollection<FormatModel>(formats);
            RoomViewModel.Seats = new ObservableCollection<SeatModel>(seats);
            CBFormatList.ItemsSource = RoomViewModel.Formats;
            LBSeatList.ItemsSource = RoomViewModel.Seats;
        }
    }
}
