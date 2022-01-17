﻿using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGenericLogic<User> _userLogic = new GenericLogic<User>();
        private MovieLogic _movieLogic;
        public MainWindow()
        {
            _userLogic = ((App)Application.Current).UserLogic;
            _movieLogic = ((App)Application.Current).MovieLogic;
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            //ResultTB.Text = _userLogic.GetUser(LoginTB.Text, PasswordTB.Text);
        }

        private void ListUserBTN_Click(object sender, RoutedEventArgs e)
        {
            //LoginGrid.Visibility = Visibility.Hidden;
            //UserListUC.Visibility = Visibility.Visible;
            var userWindow = new UserWindow();
            userWindow.Show();
        }

        private void ListmovieBTN_Click(object sender, RoutedEventArgs e)
        {
            var movieWindow = new MovieWindow();
            movieWindow.Show();
            //var listMovie3 = await _movieLogic.GetAll();
        }

    }
}
