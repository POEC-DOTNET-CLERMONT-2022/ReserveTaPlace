// See https://aka.ms/new-console-template for more information
using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ReserveTaPlace.Models;
using ReserveTaPlaceConsole;

Console.WriteLine("Bienvenue chez ResrveTaPlace.com version console !!!");
Console.WriteLine();

var manager = new Manager();
App.InitializedMoviesList();
App.Menu();



//manager.WriteQuestion(question1);
//var reponse = manager.ReadUserEntry(question1);
//Console.WriteLine(reponse.Text);
//Console.ReadLine();

