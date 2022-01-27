using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.Utils
{
    public class Navigator : ObservableObject, INavigator
    {

        private List<Control> _views;

        private ContentControl _currentContentControl;
        public Navigator()
        {
            _views = new List<Control>();
            _currentContentControl = new ContentControl();
        }
        public List<Control> Views { get { return _views; } set { _views = value; } }
        public ContentControl CurrentContentControl { get { return _currentContentControl; } set { _currentContentControl = value; OnNotifyPropertyChanged(); } }
        
        public void NavigateTo(Type type)
        {
            if (CurrentContentControl == null) return;
            var view = Views.SingleOrDefault(elt=>elt.GetType() == type);
            if (view == null) return;
            CurrentContentControl.Content = view;

        }

        public void RegisterView(Control view)
        {
            Views.Add(view);
        }
    }
}
