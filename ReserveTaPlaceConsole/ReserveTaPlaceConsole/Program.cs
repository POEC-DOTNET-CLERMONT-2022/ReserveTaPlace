// See https://aka.ms/new-console-template for more information
using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ReserveTaPlace.Models;

Console.WriteLine("Hello, World!");
var manager = new Manager();
var question1 = new Question("Quel film voulez vous ajouter ?", 0, null, null, QuestionType.ReponseLibre, null );

manager.WriteQuestion(question1);
var reponse = manager.ReadUserEntry(question1);
Console.WriteLine(reponse.Text);
Console.ReadLine();

//var movieProvider = new MovieProvider();
//await movieProvider.GetMovie("Dune");
