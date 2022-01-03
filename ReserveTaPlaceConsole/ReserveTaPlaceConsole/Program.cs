// See https://aka.ms/new-console-template for more information
using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ReserveTaPlace.Models;
using ReserveTaPlace.Persistance;
using ReserveTaPlaceConsole;


Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("                  ╦═╗╔═╗╔═╗╔═╗╦═╗╦  ╦╔═╗  ╔╦╗╔═╗  ╔═╗╦  ╔═╗╔═╗╔═╗\n"+
                  "                  ╠╦╝║╣ ╚═╗║╣ ╠╦╝╚╗╔╝║╣    ║ ╠═╣  ╠═╝║  ╠═╣║  ║╣ \n"+
                  "                  ╩╚═╚═╝╚═╝╚═╝╩╚═ ╚╝ ╚═╝   ╩ ╩ ╩  ╩  ╩═╝╩ ╩╚═╝╚═╝\n"+
                  "                              ╔═╗┌─┐┌┐┌┌─┐┌─┐┬  ┌─┐ \n"+                 
                  "                              ║  │ ││││└─┐│ ││  ├┤   \n"+
                  "                              ╚═╝└─┘┘└┘└─┘└─┘┴─┘└─┘────── ");
Console.WriteLine();
App.InitializedMoviesList();
App.InitializedUserList();
App.Menu();

var movieProvider = new MovieProvider();

Console.ReadLine();
