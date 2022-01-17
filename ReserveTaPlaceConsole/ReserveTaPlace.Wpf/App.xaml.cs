using AutoMapper;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public UserLogic UserLogic;
        public MovieLogic MovieLogic;
        public IMapper Mapper;
        public App()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(config);
            UserLogic = new UserLogic();
            MovieLogic = new MovieLogic();
        }
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
    }
}
