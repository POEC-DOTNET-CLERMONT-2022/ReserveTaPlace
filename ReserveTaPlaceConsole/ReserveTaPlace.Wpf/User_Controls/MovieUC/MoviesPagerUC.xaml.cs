using ReserveTaPlace.Models;
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

namespace ReserveTaPlace.Wpf.User_Controls.MovieUC
{
    /// <summary>
    /// Interaction logic for MoviesPagerUC.xaml
    /// </summary>
    public partial class MoviesPagerUC : UserControl
    {
        private static readonly DependencyProperty _paginatedListProperty = DependencyProperty.Register("PaginatedList", typeof(PaginatedList<MovieModel>), typeof(MoviesPagerUC));
        private PaginatedList<MovieModel> _paginatedList;
        public MoviesPagerUC()
        {
            InitializeComponent();
            DataContext = PaginatedList;
        }
        public PaginatedList<MovieModel> PaginatedList
        {
            get { return GetValue(_paginatedListProperty) as PaginatedList<MovieModel>; }
            set
            {
                if (_paginatedList != value)
                {

                    SetValue(_paginatedListProperty, value);
                }
            }
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks next page's icon")]
        public event EventHandler GoNextPage;
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks previous page's icon")]
        public event EventHandler GoPreviousPage;

        private void BTNNext_Click(object sender, RoutedEventArgs e)
        {
            if (this.GoNextPage != null)
                this.GoNextPage(this, e);
        }

        private void BTNPrev_Click(object sender, RoutedEventArgs e)
        {
            if (this.GoPreviousPage != null)
                this.GoPreviousPage(this, e);
        }
    }
}
