using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for UserPageUC.xaml
    /// </summary>
    public partial class UserPageUC : UserControl
    {
        public UserViewModel UserViewModel;
        private IDataManager<UserModel, UserDto> _dataManager;
        private IDataManager<RoleModel, RoleDto> _roledataManager;

        private int _pageIndex;
        private int _pageSize;
        public UserPageUC()
        {
            InitializeComponent();
            UserViewModel = new UserViewModel();
            _dataManager = ((App)Application.Current).UserDataManager;
            _roledataManager = ((App)Application.Current).RoleDataManager;
            _pageIndex = 1;
            _pageSize = 8;
            DataContext = UserViewModel;

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadUsers();
            await LoadRoles();
        }

        private async Task LoadRoles()
        {
            var roles = await _roledataManager.GetAll();
            UserViewModel.Roles = new ObservableCollection<RoleModel>(roles);
            UCAddUser.UserViewModel = UserViewModel;
        }

        private async Task LoadUsers()
        {
            UserViewModel.UsersPaginated = await _dataManager.GetAllPaginated(_pageIndex, _pageSize);
            UCPager.PaginatedList = UserViewModel.UsersPaginated;
            UCUsersList.Users = UserViewModel.UsersPaginated;
        }

        private async void UsersPagerUC_GoPreviousPage(object sender, EventArgs e)
        {
            _pageIndex--;
            await LoadUsers();

        }

        private async void UsersPagerUC_GoNextPage(object sender, EventArgs e)
        {
            _pageIndex++;
            await LoadUsers();

        }

        private async void UCAddUser_AddUser(object sender, EventArgs e)
        {
            if (UCAddUser.TBPassword.Text == UCAddUser.TBConfirmPassword.Text)
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(UCAddUser.TBPassword.Text);
                var user = new UserModel(UCAddUser.TBFirstName.Text, UCAddUser.TBLastName.Text, UCAddUser.TBEMail.Text, passwordHash);
                //var user = new UserModel("Simon", "Bascobert", "Simon.Bascobert@gmail.com", passwordHash);
                var role = UCAddUser.CBRoles.SelectedItem as RoleModel;
                user.Roles.Add(role);
                var result = await _dataManager.Add(user);
                if (result)
                {
                    await LoadUsers();
                }

            }
        }

        private async void BTNSearchUser_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TBEmail.Text))
            {
                var user = await _dataManager.GetUserByEmail(TBEmail.Text);
                UCUserDetails.User = user;
            }
        }

        private async void BTNReload_Click(object sender, RoutedEventArgs e)
        {
            await LoadUsers();
        }
    }
}
