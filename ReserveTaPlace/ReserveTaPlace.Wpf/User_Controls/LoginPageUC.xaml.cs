using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Wpf.Utils;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for LoginPageUC.xaml
    /// </summary>
    public partial class LoginPageUC : UserControl
    {
        public INavigator Navigator { get; set; }
        private IDataManager<UserModel, UserDto> _userDataManager;

        public LoginPageUC()
        {
            InitializeComponent();
            Navigator = ((App)Application.Current).Navigator;
            _userDataManager = ((App)Application.Current).UserDataManager;
            TBLogin.Text = "jul.boisserie@gmail.com";
        }

        private async void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text!=null && TBLogin.Text != null && TBPassword.Text != String.Empty && TBLogin.Text != String.Empty)
            {
                if (await CheckUser(TBPassword.Text,TBLogin.Text))
                {
                    Navigator.NavigateTo(typeof(HomePage));
                }
            }

        }

        private async Task<bool> CheckUser(string password,string email)
        {
            string passwordHash = await _userDataManager.GetUserHash(email);
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
