using AutoMapper;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Logique d'interaction pour UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private IGenericLogic<User> _userLogic = new GenericLogic<User>();
        private readonly IMapper _mapper;
        private ListUsers _listUser;
        public UserWindow()
        {
            _listUser = new ListUsers();
            _mapper = ((App)Application.Current).Mapper;
            _userLogic = ((App)Application.Current).UserLogic;
            InitializeComponent();
            LoadUsers();
            DataContext = _listUser;
        }
        public async void LoadUsers()
        {
            var users = await _userLogic.GetAll();
            var userModels = _mapper.Map<IEnumerable<User>>(users);
            _listUser.Users = new ObservableCollection<User>(userModels);
        }
    }
}
