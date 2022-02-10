using MaterialDesignThemes.Wpf;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.Wpf.Utils;
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

namespace ReserveTaPlace.Wpf.User_Controls.MovieUC
{
    /// <summary>
    /// Interaction logic for PutMovieOnScreenUC.xaml
    /// </summary>
    public partial class PutMovieOnScreenUC : UserControl
    {
        private static readonly DependencyProperty _sessionViewModelProperty = DependencyProperty.Register("SessionViewModel", typeof(SessionViewModel), typeof(PutMovieOnScreenUC));
        private SessionViewModel _sessionViewModel;
        private IDataManager<CalendarModel, CalendarDto> _calendarDataManager;
        public SessionViewModel SessionViewModel
        {
            get { return GetValue(_sessionViewModelProperty) as SessionViewModel; }
            set
            {
                if (_sessionViewModel != value)
                {
                    SetValue(_sessionViewModelProperty, value);
                }
            }
        }
        public PutMovieOnScreenUC()
        {
            InitializeComponent();
            _calendarDataManager = ((App)Application.Current).CalendarDataManager;
            DataContext = SessionViewModel;
        }

        private async void DPStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DPStartDate.SelectedDate.HasValue)
            {
                DateTime startDate = DPStartDate.SelectedDate.HasValue ? DPStartDate.SelectedDate.Value : DateTime.UtcNow ;
                DateTime endDate = DPEndDate.SelectedDate.HasValue ? DPEndDate.SelectedDate.Value : DateTime.UtcNow;
                List<DateTime> dates = new List<DateTime>();
                TimeSpan ts = endDate - startDate;
                int numberOfDays = ts.Days;
                for (int i = 0; i < numberOfDays; i++)
                {
                    var dateToGet = startDate.Add(new TimeSpan(i,0, 0, 0)).ToString();
                    //SessionViewModel.CurrentCalendar = await _calendarDataManager.GetCalendarByDate(dateToGet);
                    //SessionViewModel.Calendars.Add(SessionViewModel.CurrentCalendar);

                }
            }
        }

        private void DPEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void BTNGenerateCalendar_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = DateTime.UtcNow.AddDays(10000);
            var calendar = CalendarGenerator.GetDateRange(startDate, endDate).ToList();
            foreach (var dateItem in calendar)
            {
                var calendarModel = new CalendarModel(dateItem.Date);
                await _calendarDataManager.AddCalendar(calendarModel);
            }
        }
    }
}
