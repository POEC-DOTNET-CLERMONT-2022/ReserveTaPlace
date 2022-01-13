// See https://aka.ms/new-console-template for more information
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
var app = new App();
await app.InitializedMoviesList();
app.InitializedUserList();
await app.Menu();

