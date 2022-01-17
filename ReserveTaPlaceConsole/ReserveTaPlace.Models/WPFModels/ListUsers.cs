using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels
{
    public class ListUsers : ObservableObject
    {
        private ObservableCollection<User> _users;
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                if(value != _users)
                {
                    _users = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
