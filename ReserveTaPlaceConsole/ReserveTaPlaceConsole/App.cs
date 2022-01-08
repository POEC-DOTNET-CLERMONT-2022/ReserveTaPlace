using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
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
        private Manager _manager;
        private MovieManager _movieManager;
        public App()
        {
            _manager = new Manager();
            _movieManager = new MovieManager();
        }
        public async Task Menu()
        {
            await _movieManager.GetAllMovies();
            var question = new Question("Choisir une action a effectuer : \n" +
                "1.Afficher la liste des films disponibles\n" +
                "2.Choisir un film a mettre a l'affiche\n" +
                "3.Ajouter un film\n" +
                "4.Supprimer un film\n"+
                "5.Quitter",
                5,QuestionType.ChoixMultiple);

            _manager.WriteQuestion(question);
            var answer = _manager.ReadUserEntry(question);

            switch (answer.Choice)
            {
                case 1:
                    _movieManager.DisplayMovies();
                    break;
                case 2:
                    break;
                case 3:
                    var question1 = new Question("Quel est le titre du film que vous voulez ajouter ?", 0, QuestionType.ReponseLibre);
                    _manager.WriteQuestion(question1);
                    var answer1 = _manager.ReadUserEntry(question1);
                    var question2 = new Question($"Indiquez l'année de sortie du film : {answer1.Text}", 0, QuestionType.ReponseLibre);
                    _manager.WriteQuestion(question2);
                    var answer2 = _manager.ReadUserEntry(question2);
                    var movie = await _movieManager.GetMovie(answer1.Text, answer2.Text);
                    _movieManager.Add(movie);
                    Console.WriteLine($"Le film {movie.Title} est ajouté à la liste des films disponibles.");
                    _movieManager.DisplayMovies();
                    break;
                case 4:
                    var question3 = new Question("Entrer le nom du film à supprimer : ", 0, QuestionType.ReponseLibre);
                    _manager.WriteQuestion(question3);
                    var answer3 = _manager.ReadUserEntry(question3);
                    _movieManager.Delete(answer3.Text);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            await this.Menu();
            //var question3 = new Question("Selectionner le film :", 0, null, null, QuestionType.ReponseLibre, null);

        }

        public async Task InitializedMoviesList()
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

        public void InitializedUserList()
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
