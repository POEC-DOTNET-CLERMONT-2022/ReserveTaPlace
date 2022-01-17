using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void InitializedUserList()
        {
            var userList = new List<User>() {
                new User("Gilbert", "Hugo", "hugo.g@hotmail.fr", "1234"),
                new User("Gerard", "Bidon", "bidon.g@hotmail.fr", "1234", UserRoles.AdminLocal),
                new User("Bernard", "Petard", "petard.b@hotmail.fr", "1234", UserRoles.AdminGroupe),
                new User("Jean", "Casser", "casser.j@hotmail.fr", "1234", UserRoles.AdminGlobal)};

            var userManager = new UserLogic();
            userManager.SaveUsers(userList);

        }
        public static void InitializedMoviesList()
        {
            var movieLogic = new MovieLogic();

            //var movieList = movieLogic.GetAllMovies();

            //movieLogic.SaveMovies(movieList);
        }
    }
}
