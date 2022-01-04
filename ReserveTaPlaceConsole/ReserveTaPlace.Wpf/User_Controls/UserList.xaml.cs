﻿using ReserveTaPlace.Logic;
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
    /// Logique d'interaction pour UserList.xaml
    /// </summary>
    public partial class UserList : UserControl
    {
        UserLogic userLogic = new UserLogic();
        public UserList()
        {
            InitializeComponent();

        }
        private async void UserLV_Loaded(object sender, RoutedEventArgs e)
        {
            UserLV.ItemsSource = await userLogic.GetUsers();
        }
    }
}
