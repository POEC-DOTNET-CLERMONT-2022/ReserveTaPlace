// See https://aka.ms/new-console-template for more information
using ReserveTaPlace.Models;

Console.WriteLine("Hello, World!");


var movieProvider = new MovieProvider();
await movieProvider.GetMovie("Dune");
