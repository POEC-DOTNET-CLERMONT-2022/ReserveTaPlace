using MaterialDesignThemes.Wpf;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DPStartDate.DisplayDateStart = DateTime.Now;
            DPStartDate.DisplayDateEnd = DateTime.Now.Add(new TimeSpan(400, 0, 0, 0));
            DPEndDate.DisplayDateStart = DateTime.Now;
            DPEndDate.DisplayDateEnd = DateTime.Now.Add(new TimeSpan(400, 0, 0, 0));
        }
        private async Task PopulateCalendars()
        {

            if (DPStartDate.SelectedDate.HasValue && DPEndDate.SelectedDate.HasValue && DPStartDate.SelectedDate.Value < DPEndDate.SelectedDate.Value)
            {
                var calendars = new List<CalendarModel>();
                DateTime startDate = DPStartDate.SelectedDate.HasValue ? DPStartDate.SelectedDate.Value : DateTime.UtcNow;
                DateTime endDate = DPEndDate.SelectedDate.HasValue ? DPEndDate.SelectedDate.Value : DateTime.UtcNow;
                TimeSpan ts = endDate - startDate;
                int numberOfDays = ts.Days;
                if (numberOfDays==0)
                {
                    Calendar.DisplayDateStart = DateTime.UtcNow;
                    Calendar.DisplayDateEnd = DateTime.UtcNow;

                }
                else
                {
                    for (int i = 0; i < numberOfDays; i++)
                    {
                        var dateToGet = startDate.Add(new TimeSpan(i, 0, 0, 0)).ToString();
                        var calendar = await _calendarDataManager.GetCalendarByDate(dateToGet);
                        calendars.Add(calendar);
                    }
                    SessionViewModel.Calendars = new ObservableCollection<CalendarModel>(calendars);
                    Calendar.DisplayDateStart = SessionViewModel.Calendars.First().Date;
                    Calendar.DisplayDateEnd = SessionViewModel.Calendars.Last().Date;
                }

            }
            else
            {
                Calendar.DisplayDateStart = DateTime.UtcNow;
                Calendar.DisplayDateEnd = DateTime.UtcNow;
            }

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
        private void PopulateSchedules()
        {
            if (DPStartHour.SelectedTime.HasValue && DPEndHour.SelectedTime.HasValue && DPStartHour.SelectedTime.Value< DPEndHour.SelectedTime.Value)
            {
                DateTime startHour = DPStartHour.SelectedTime.Value;
                DateTime endHour = DPEndHour.SelectedTime.Value;
                var schedule = new ScheduleModel(startHour, endHour);
                var schedules = new List<ScheduleModel>();
                schedules.Add(schedule);
                SessionViewModel.Schedules = new ObservableCollection<ScheduleModel>(schedules);
                LBSchedules.Items.Add(schedule);
            }

        }
        private void BTNAddSchedule_Click(object sender, RoutedEventArgs e)
        {
            PopulateSchedules();
        }
        private async void BTNAddCalendar_Click(object sender, RoutedEventArgs e)
        {
            await PopulateCalendars();

        }

        private void BTNReset_Click(object sender, RoutedEventArgs e)
        {
            LBSchedules.Items.Clear();
            SessionViewModel.Calendars = null;
            SessionViewModel.Schedules = null;
        }
    }
}
