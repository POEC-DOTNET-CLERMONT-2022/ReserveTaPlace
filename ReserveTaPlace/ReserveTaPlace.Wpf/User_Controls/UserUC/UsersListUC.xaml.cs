using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UsersListUC.xaml
    /// </summary>
    public partial class UsersListUC : UserControl
    {
        private static readonly DependencyProperty _usersProperty = DependencyProperty
            .Register("Users", typeof(PaginatedList<UserModel>), typeof(UsersListUC));
        private PaginatedList<UserModel> _users;
        public UserModel SelectedUser { get; set; }

        public PaginatedList<UserModel> Users
        {
            get { return GetValue(_usersProperty) as PaginatedList<UserModel>; }
            set
            {
                if (_users != value)
                {
                    SetValue(_usersProperty, value);
                }
            }
        }
        public UsersListUC()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks on a movie in the list")]
        public event EventHandler SelectionChanged;
        private void LBUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.SelectionChanged != null)
                this.SelectionChanged(this, e);
        }
    }
}
