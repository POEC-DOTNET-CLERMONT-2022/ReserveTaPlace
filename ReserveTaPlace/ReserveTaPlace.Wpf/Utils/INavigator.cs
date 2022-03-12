using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.Utils
{
    public interface INavigator
    {
        void NavigateTo(Type type);
        void RegisterView(Control view);
        ContentControl CurrentContentControl { get; set; }
        //void Back();
        //bool CanGoBack();
    }
}
