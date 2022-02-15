using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
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
            var users = await _dataManager.GetAllPaginated(_pageIndex, _pageSize);
            UserViewModel.Users = new ObservableCollection<UserModel>(users.Data);
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

        private void UCAddUser_AddUser(object sender, EventArgs e)
        {
            if (UCAddUser.TBPassword.Text == UCAddUser.TBConfirmPassword.Text)
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(UCAddUser.TBPassword.Text);
                //var user = new UserModel(UCAddUser.TBFirstName.Text, UCAddUser.TBLastName.Text, UCAddUser.TBEMail.Text, passwordHash);
                var user = new UserModel("Julien", "Boisserie", "jul.boisserie@gmail.com", passwordHash);
                var role = UCAddUser.CBRoles.SelectedItem as RoleModel;
                user.Roles.Add(role);
                _dataManager.Add(user);
            }
        }
    }
}
