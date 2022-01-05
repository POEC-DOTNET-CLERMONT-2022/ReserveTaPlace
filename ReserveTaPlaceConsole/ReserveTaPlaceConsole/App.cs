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
    abstract class App
    {
        public async static void Menu()
        {
            var manager = new Manager();
            var movieManager = new MovieManager();
            var question = new Question("Choisir une action a effectuer : \n" +
                "1.Afficher la liste des films disponibles\n" +
                "2.Choisir un film a mettre a l'affiche\n" +
                "3.Ajouter un film\n" +
                "4.Supprimer un film\n" +
                "5.Modifier un film",
                5,QuestionType.ChoixMultiple);

            manager.WriteQuestion(question);
            var answer = manager.ReadUserEntry(question);

            switch (answer.Choice)
            {
                case 1:
                    await movieManager.GetAllMovies();
                    movieManager.DisplayMovies();
                    Console.ReadLine();
                    break;
                case 2:
                    break;
                case 3:
                    var question1 = new Question("Quel est le titre du film que vous voulez ajouter ?", 0, QuestionType.ReponseLibre);
                    manager.WriteQuestion(question1);
                    var answer1 = manager.ReadUserEntry(question1);
                    var question2 = new Question($"Indiquez l'année de sortie du film : {answer1.Text}", 0, QuestionType.ReponseLibre);
                    manager.WriteQuestion(question2);
                    var answer2 = manager.ReadUserEntry(question2);
                    var movie = await movieManager.GetMovie(answer1.Text, answer2.Text);
                    movieManager.Movies.Append(movie);
                    movieManager.SaveMovies(movieManager.Movies);
                    Console.WriteLine($"Le film {movie.Title} est ajouté à la liste des films disponibles.");
                    Console.ReadLine();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
            var question3 = new Question("Selectionner le film :", 0, null, null, QuestionType.ReponseLibre, null);
        }

        public static void InitializedMoviesList()
        {
            var movieManager = new MovieManager();

            List<Movie> movieList = new List<Movie>() {
                new Movie("Alien"), 
                new Movie("Dune"), 
                new Movie("Terminator"),
                new Movie("Iron Man"),
                new Movie("La vie d'Adèle"),
                new Movie("Matrix 4"),
                new Movie("Le dernier duel"),
                new Movie("Detective Pikachu")};

            movieManager.SaveMovies(movieList);
        }

        public static void InitializedUserList()
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
