using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ReserveTaPlace.Wpf.User_Controls.UserUC
{
    /// <summary>
    /// Interaction logic for AddUserUC.xaml
    /// </summary>
    public partial class AddUserUC : UserControl
    {
        private static readonly DependencyProperty _userViewModelProperty = DependencyProperty
            .Register("UserViewModel", typeof(UserViewModel), typeof(AddUserUC));
        private UserViewModel _userViewModel;

        public UserViewModel UserViewModel
        {
            get { return GetValue(_userViewModelProperty) as UserViewModel; }
            set
            {
                if (_userViewModel != value)
                {
                    SetValue(_userViewModelProperty, value);
                }
            }
        }
        public string Role { get; set; }
        public AddUserUC()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks previous page's icon")]
        public event EventHandler GoBack;
        private void BTNGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.GoBack != null)
                this.GoBack(this, e);
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks on addUser button")]
        public event EventHandler AddUser;
        private void BTNAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (this.AddUser != null)
                this.AddUser(this, e);
        }
    }

}
