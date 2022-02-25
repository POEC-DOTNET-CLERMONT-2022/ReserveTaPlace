using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels.StateManager
{
    public class TheaterPageStateManager : INotifyPropertyChanged
    {
        private bool _isAddTheaterVisible;
        private bool _isAddRoomVisible;
        private bool _isTheaterListVisible;
        private bool _isTheaterDetailsVisible;
        private bool _isUpdateTheaterVisible;
        private bool _isUpdateRoomVisible;

        public bool IsAddTheaterVisible { get => _isAddTheaterVisible; set { _isAddTheaterVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsAddRoomVisible { get => _isAddRoomVisible; set { _isAddRoomVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsTheaterListVisible { get => _isTheaterListVisible; set { _isTheaterListVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsTheaterDetailsVisible { get => _isTheaterDetailsVisible; set { _isTheaterDetailsVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsUpdateTheaterVisible { get => _isUpdateTheaterVisible; set { _isUpdateTheaterVisible = value; OnNotifyPropertyChanged(); } }
        public bool IsUpdateRoomVisible { get => _isUpdateRoomVisible; set { _isUpdateRoomVisible = value; OnNotifyPropertyChanged(); } }

        public TheaterPageStateManager(TheaterPageState state)
        {
            Set(state);
        }

        public void Set(TheaterPageState state)
        {
            switch (state)
            {
                case TheaterPageState.TheaterListView:
                    IsAddTheaterVisible = false;
                    IsAddRoomVisible = false;
                    IsTheaterListVisible = true;
                    IsTheaterDetailsVisible = true;
                    IsUpdateTheaterVisible = false;
                    IsUpdateRoomVisible = false;
                    break;
                case TheaterPageState.AddRoomView:
                    IsAddTheaterVisible = true;
                    IsAddRoomVisible = true;
                    IsTheaterListVisible = false;
                    IsTheaterDetailsVisible = false;
                    IsUpdateTheaterVisible = false;
                    IsUpdateRoomVisible = false;
                    break;
                case TheaterPageState.AddTheaterView:
                    IsAddTheaterVisible = true;
                    IsAddRoomVisible = false;
                    IsTheaterListVisible = false;
                    IsTheaterDetailsVisible = false;
                    IsUpdateTheaterVisible = false;
                    IsUpdateRoomVisible = false;
                    break;
                case TheaterPageState.UpdateTheaterView:
                    IsAddTheaterVisible = false;
                    IsAddRoomVisible = false;
                    IsTheaterListVisible = false;
                    IsTheaterDetailsVisible = false;
                    IsUpdateTheaterVisible = true;
                    IsUpdateRoomVisible = false;
                    break;
                case TheaterPageState.UpdateRoomView:
                    IsAddTheaterVisible = false;
                    IsAddRoomVisible = false;
                    IsTheaterListVisible = false;
                    IsTheaterDetailsVisible = false;
                    IsUpdateTheaterVisible = false;
                    IsUpdateRoomVisible = true;
                    break;
                default:
                    break;
            }
        }

        protected virtual void OnNotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
