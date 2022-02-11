using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            _theaterDataManager = ((App)Application.Current).TheaterDataManager;
            DataContext = TheaterViewModel;
            
        }


        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var theaters = await _theaterDataManager.GetAll();
            TheaterViewModel.Theaters = new ObservableCollection<TheaterModel>(theaters);
            //var roomList = _theaterViewModel.CurrentTheater.Rooms;
            //foreach (var room in roomList)
            //{
            //    room.
            //}
            //_theaterViewModel.SeatList = new ObservableCollection<SeatModel>()
            TheaterListUC.Theaters = TheaterViewModel.Theaters;
        }

        private void TheaterListUC_SelectionChanged(object sender, System.EventArgs e)
        {
            TheaterViewModel.CurrentTheater = TheaterListUC.LVTheaters.SelectedItem as TheaterModel;
            TheaterDetailsUC.TheaterViewModel = TheaterViewModel;
        }
    }
}
