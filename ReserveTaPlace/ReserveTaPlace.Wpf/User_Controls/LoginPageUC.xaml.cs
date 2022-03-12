using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
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
            if (TBPassword.Password!=null && TBLogin.Text != null && TBPassword.Password != String.Empty && TBLogin.Text != String.Empty)
            {
                if (await CheckUser(TBPassword.Password, TBLogin.Text))
                {
                    Navigator.NavigateTo(typeof(HomePage));
                }
            }

        }

        private async Task<bool> CheckUser(string password,string email)
        {
            var userToVerify = new UserToVerify() { Password = password, Email = email };   
            var result = await _userDataManager.VerifyUser(userToVerify);
            return result;
        }
    }
}
