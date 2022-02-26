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
        public RoomViewModel RoomViewModel { get; set; }
        private readonly IDataManager<FormatModel, FormatDto> _formatDataManager;
        private readonly IDataManager<SeatModel, SeatDto> _seatDataManager;
        private List<RowModel> _rowModels;
        public AddRoomUC()
        {
            InitializeComponent();
            _formatDataManager = ((App)Application.Current).FormatDataManager;
            _seatDataManager = ((App)Application.Current).SeatDataManager;
            RoomViewModel = new RoomViewModel();
            _rowModels = new List<RowModel>();
        }

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
            CBRowName.ItemsSource = RoomViewModel.Row.RowLetters;
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(UDTotalSeat.Text)&& !String.IsNullOrEmpty(CBRowName.Text))
            {
                var row = new RowModel() { RowLetter = CBRowName.Text, TotalSeat = UDTotalSeat.Text };
                _rowModels.Add(row);
                RoomViewModel.RowModels = new ObservableCollection<RowModel>(_rowModels);
                LBRowSeat.ItemsSource = RoomViewModel.RowModels;
            }
        }
    }
}
