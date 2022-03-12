using ReserveTaPlace.Models;
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
    /// Interaction logic for UserDetailsUC.xaml
    /// </summary>
    public partial class UserDetailsUC : UserControl
    {
        private static readonly DependencyProperty _userProperty = DependencyProperty
       .Register("User", typeof(UserModel), typeof(UserDetailsUC));
        private UserModel _user;
        public UserModel User
        {
            get { return GetValue(_userProperty) as UserModel; }
            set
            {
                if (_user != value)
                {
                    SetValue(_userProperty, value);
                }
            }
        }
        public UserDetailsUC()
        {
            InitializeComponent();
        }
    }
}
