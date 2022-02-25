using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls.TheaterUC
{
    /// <summary>
    /// Logique d'interaction pour TheaterAddUC.xaml
    /// </summary>
    public partial class AddTheaterUC : UserControl
    {
        private static readonly DependencyProperty _theaterViewModelProperty = DependencyProperty.Register("TheaterViewModel", typeof(TheaterViewModel), typeof(AddTheaterUC));
        private RoomViewModel _roomViewModel;
        private readonly IDataManager<TheaterModel, TheaterDto> _theaterDataManager;
        private TheaterViewModel _theaterViewModel;
        public AddTheaterUC()
        {
            InitializeComponent();
            _roomViewModel = new RoomViewModel();
        }
        public TheaterViewModel TheaterViewModel
        {
            get { return GetValue(_theaterViewModelProperty) as TheaterViewModel; }
            set
            {
                if (_theaterViewModel != value)
                {
                    SetValue(_theaterViewModelProperty, value);
                }
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks on button createTheater")]
        public event EventHandler CreateRoom;
        private void BTNCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (this.CreateRoom != null)
                this.CreateRoom(this, e);
        }
    }
}
