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
        [Description("Invoked when user clicks on button createRoom")]
        public event EventHandler CreateRoom;
        private void BTNCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (this.CreateRoom != null)
                this.CreateRoom(this, e);
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

        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            TBTheaterStreet.Text = "Av.Lavoisier";
            TBTheaterPostalCode.Text = "63170";
            TBTheaterCity.Text = "Aubière";
            TBTheaterCounty.Text = "France";
            TBTheaterName.Text = "Ciné Dôme";
        }
    }
}
