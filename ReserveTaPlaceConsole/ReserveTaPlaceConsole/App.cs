using ReserveTaPlace.Models.ConsoleModels;
using ReserveTaPlace.AppManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.RTPManager;
using ReserveTaPlaceConsole.RTPManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole
{
    internal class App
    {
        private IAppManager _manager;
        private MovieManager _movieManager;
        public App()
        {
            _manager = new Manager();
            _movieManager = new MovieManager();
        }
        internal async Task Menu()
        {
            await _movieManager.GetAllMovies();
            var question = new Question("Choisir une action a effectuer : \n" +
                "1.Afficher la liste des films disponibles\n" +
                "2.Afficher la liste des films à l'affiche\n" +
                "3.Choisir un film a mettre a l'affiche\n" +
                "4.Ajouter un film\n" +
                "5.Supprimer un film\n"+
                "6.Quitter",
                6,QuestionType.ChoixMultiple);
            Console.WriteLine();

            _manager.WriteQuestion(question);
            var answer = _manager.ReadUserEntry(question);

            switch (answer.Choice)
            {
                case 1:
                    _movieManager.DisplayMovies();
                    break;
                case 2:
                    _movieManager.DisplayOnDisplayMovies();
                    break;
                case 3:
                    await _movieManager.PutOnDisplay();
                    break;
                case 4:
                    var movies = await _movieManager.GetMovie();
                    await _movieManager.Add(movies[0]);
                    Console.WriteLine($"Le film {movies[0].Title} est ajouté à la liste des films disponibles.");
                    _movieManager.DisplayMovies();
                    break;
                case 5:
                    await _movieManager.Delete();
                    _movieManager.DisplayMovies();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            await this.Menu();
        }

        internal async Task InitializedMoviesList()
        {
            var movieManager = new MovieManager();
            var moviesModifyed = movieManager.Movies as List<Movie>;
            
            moviesModifyed.Add(new Movie(movieManager.CalculateId(), "Predator"));
            moviesModifyed.Add(new Movie(movieManager.CalculateId(), "Predator a delete"));
            moviesModifyed.Add(new Movie(movieManager.CalculateId(), "Rambo"));
            moviesModifyed.Add(new Movie(movieManager.CalculateId(), "Rocky"));
            moviesModifyed.Add(new Movie(movieManager.CalculateId(), "les tuches"));
            moviesModifyed.Add(new Movie(movieManager.CalculateId(), "le pere noel est une ordure"));

            movieManager.Movies = moviesModifyed;
            await movieManager.SaveMovies();
        }

        internal void InitializedUserList()
        {
            var userList = new List<User>() { 
                new User("Gilbert", "Hugo", "hugo.g@hotmail.fr", "1234"),
                new User("Gerard", "Bidon", "bidon.g@hotmail.fr", "1234",UserRoles.AdminLocal),
                new User("Bernard", "Petard", "petard.b@hotmail.fr", "1234", UserRoles.AdminGroupe),
                new User("Jean", "Casser", "casser.j@hotmail.fr", "1234", UserRoles.AdminGlobal)};

            var userManager = new UserManager(userList);
            userManager.SaveUsers(userList);

        }
    }
}
