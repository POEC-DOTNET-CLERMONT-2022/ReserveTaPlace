using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for UserPageUC.xaml
    /// </summary>
    public partial class UserPageUC : UserControl
    {
        private UserViewModel _userViewModel;
        private IDataManager<UserModel, UserDto> _dataManager;
        private int _pageIndex;
        private int _pageSize;
        public UserPageUC()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel();
            _dataManager = ((App)Application.Current).UserDataManager;
            _pageIndex = 1;
            _pageSize = 8;
            DataContext = _userViewModel;

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            var users = await _dataManager.GetAllPaginated(_pageIndex, _pageSize);

        }
    }
}
