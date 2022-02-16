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

        //TODO : à supprimer
        //private IGenericLogic<UserModel> _userLogic = new GenericLogic<UserModel>();
        //private readonly IMapper _mapper;
        //private ListUsers _listUser;
        //public UserWindow()
        //{
        //    _listUser = new ListUsers();
        //    _mapper = ((App)Application.Current).Mapper;
        //    _userLogic = ((App)Application.Current).UserLogic;
        //    InitializeComponent();
        //    LoadUsers();
        //    DataContext = _listUser;
        //}
        //public async void LoadUsers()
        //{
        //    var users = await _userLogic.GetAll();
        //    var userModels = _mapper.Map<IEnumerable<UserModel>>(users);
        //    _listUser.Users = new ObservableCollection<UserModel>(userModels);
        //}

        //private void AddUser_Click(object sender, RoutedEventArgs e)
        //{
        //    string password = "";
        //    if (TBpassword.Text==TBpasswordConfirmation.Text)
        //    {
        //        password = TBpassword.Text;
        //    }
        //    var newUser = new UserModel(TBfirstName.Text,TBlastName.Text,TBmail.Text, password);
        //    _listUser.Users.Add(newUser);

        //}
    }
}
