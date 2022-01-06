// See https://aka.ms/new-console-template for more information
using PatternObserver;

Console.WriteLine("Hello, World!");

//var subject = new Subject();
//var observerA = new ConcreteObserverA();
//subject.Attach(observerA);

//var observerB = new ConcreteObserverB();
//subject.Attach(observerB);

//subject.SomeBusinessLogic();
//subject.SomeBusinessLogic();

//subject.Detach(observerB);

//subject.SomeBusinessLogic();

var movie = new Movie("Spider-man");
var movieObserver = new MovieObserver();
var movieLogic = new MovieLogic();
movieLogic.Attach(movieObserver);

movieLogic.AddNewMovie(movie);