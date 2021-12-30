using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.RTPManager;
using ReserveTaPlace.RTPManager.Interfaces;
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
        IReader _reader = new Reader();
        IWriter _writer = new Writer();
        public static void Menu()
        {
            var manager = new Manager();
            var movieProvider = new MovieProviderLogic();
            var movieManager = new MovieManager();
            var question = new Question("Choisir une action a effectuer : \n" +
                "1.Afficher la liste des films disponibles\n" +
                "2.Choisir un film a mettre a l'affiche\n" +
                "3.Ajouter un film\n" +
                "4.Supprimer un film\n" +
                "5.Modifier un film",
                5, null, null, QuestionType.ChoixMultiple, null);

            manager.WriteQuestion(question);
            var answer = manager.ReadUserEntry(question);

            switch (answer.Choice)
            {
                case 1:
                    movieManager.LoadMovies();
                    movieManager.Read();
                    Console.ReadLine();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }


            var question1 = new Question("Quel film voulez vous ajouter ?", 0, null, null, QuestionType.ReponseLibre, null);

            var question2 = new Question("Selectionner le film :", 0, null, null, QuestionType.ReponseLibre, null);

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
    }
}
