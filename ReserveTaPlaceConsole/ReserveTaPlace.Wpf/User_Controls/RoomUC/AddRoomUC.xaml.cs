using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
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


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks on AddRoom")]
        public event EventHandler AddRoom;
        private void BTNAddRoom_Click(object sender, RoutedEventArgs e)
        {
            if (this.AddRoom != null)
                this.AddRoom(this, e);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var formats = await _formatDataManager.GetAll();
            RoomViewModel.Formats = new ObservableCollection<FormatModel>(formats);
            CBFormatList.ItemsSource = RoomViewModel.Formats;
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(UDTotalSeat.Text)&& String.IsNullOrEmpty(TBRowName.Text))
            {
                var row = new RowModel() { RowLetter = TBRowName.Text, TotalSeat = UDTotalSeat.Text };
                RoomViewModel.RowModels.Add(row);
                LBRowSeat.ItemsSource = RoomViewModel.RowModels;
            }
        }
    }
}
