using AutoMapper;
using ReserveTaPlace.AppManager;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models.CModels;
using ReserveTaPlace.RTPManager.Interfaces;
using ReserveTaPlaceConsole.RTPManager;


namespace ReserveTaPlace.RTPManager
{
    public class MovieManager
    {
        private PersistanceLogic _persistanceLogic;
        private IMovieProviderLogic _movieProviderLogic;
        private IAppManager _manager;
        private IWriter _writer { get; }
        private IEnumerable<Movie> _movies;
        public IEnumerable<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }
        private IMapper Mapper;
        internal MovieManager()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ReserveTaPlaceConsole.App)));
            _writer = new Writer();
            _movies = new List<Movie>();
            _persistanceLogic = new PersistanceLogic();
            _movieProviderLogic = new MovieProviderLogic();
            _manager = new Manager();
            Mapper = new Mapper(config);
        }
        internal void DisplayMovies()
        {
            Console.WriteLine("╔════════════════ Liste des films disponible ═══════════╗");
            _writer.DisplayMovies(Movies);
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        }
        internal async Task SaveMovies()
        {
            await _persistanceLogic.SaveMovies(Movies);
        }
        internal async Task GetAllMovies()
        {
            Movies = await _persistanceLogic.GetAllMovies();
        }

        internal void DisplayOnDisplayMovies()
        {
            Console.WriteLine("╔════════════════ Liste des films à l'affiche ═══════════╗");
            _writer.DisplayOnDisplayMovies(Movies);
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        }

        internal async Task<List<Movie>> GetMovie()
        {
            var movies = new List<Movie>();
            do
            {
                var question3 = new Question("Quel est le titre du film que vous voulez ajouter ?", 0, QuestionType.ReponseLibre);
                _manager.WriteQuestion(question3);
                var answer3 = _manager.ReadUserEntry(question3);
                var question3_1 = new Question($"Indiquez l'année de sortie du film : {answer3.Text}", 0, QuestionType.ReponseLibre);
                _manager.WriteQuestion(question3_1);
                var answer3_1 = _manager.ReadUserEntry(question3_1);
                movies = Mapper.Map<List<Movie>>(await _movieProviderLogic.GetMovie(answer3.Text, answer3_1.Text));
            } while (movies.Count == 0);
            if (movies.Count == 1)
            {
                movies[0].IdC = this.CalculateId();
            }

            return movies;
        }

        internal async Task PutOnDisplay()
        {
            var moviesListResult = new List<Movie>();
            do
            {
                var question2 = new Question("Quel est le titre du film que vous voulez mettre a l'affiche ?", 0, QuestionType.ReponseLibre);
                _manager.WriteQuestion(question2);
                var answer2 = _manager.ReadUserEntry(question2);
                moviesListResult = Search(answer2.Text);
                DisplayMovies();

            } while (moviesListResult.Count == 0);
            if (moviesListResult.Count == 1)
            {
                var movie = moviesListResult[0];
                Movies.FirstOrDefault(m => m.IdC == movie.IdC).IsMovieOnDisplay = true;
                await _persistanceLogic.SaveMovies(Movies);
                Console.WriteLine($"Le film {movie.Title} est à l'affiche.");
                DisplayOnDisplayMovies();
            }
            else
            {
                Console.WriteLine($"Votre recherche comporte plusieurs résultats :");
                _writer.DisplayMovies(moviesListResult);
                var question = new Question("Entrer l'id du film à mettre à l'affiche :", QuestionType.Numerique);
                _manager.WriteQuestion(question);
                var answer = _manager.ReadUserEntry(question);
                Movies.FirstOrDefault(m => m.IdC == int.Parse(answer.Text)).IsMovieOnDisplay = true;
                var movieToPutOnDisplay = Movies.FirstOrDefault(m => m.IdC == int.Parse(answer.Text));
                await _persistanceLogic.SaveMovies(Movies);
                Console.WriteLine($"Le film {movieToPutOnDisplay.Title} a été mis à l'affiche !!");
                DisplayOnDisplayMovies();
            }
        }

        internal List<Movie> Search(string movieTitle)
        {
            var moviesListResult = Movies.Where(e => e.Title.ToLower().StartsWith(movieTitle.ToLower())).ToList();
            if (moviesListResult.Count == 0)
            {
                Console.WriteLine($"Le film {movieTitle} n'existe pas !!");
                return moviesListResult;
            }
            return moviesListResult;
        }

        internal async Task Add(Movie movie)
        {
            var moviesModifyed = Movies as List<Movie>;
            moviesModifyed.Add(movie);
            Movies = moviesModifyed;
            await _persistanceLogic.SaveMovies(Movies);
            Console.WriteLine($"Le film {movie.Title} est ajouté à la liste des films disponibles.");

        }

        internal async Task Delete()
        {
            var moviesListResult = new List<Movie>();
            string movieTitle = "";
            do
            {
                var question4 = new Question("Entrer le nom du film à supprimer : ", 0, QuestionType.ReponseLibre);
                _manager.WriteQuestion(question4);
                var answer4 = _manager.ReadUserEntry(question4);
                moviesListResult = Search(answer4.Text);
                movieTitle = answer4.Text;
            } while (moviesListResult.Count == 0);
            if (moviesListResult.Count == 1)
            {
                var moviesModifyed = Movies.Where(e => e.Title.ToLower() != moviesListResult[0].Title.ToLower());
                Movies = moviesModifyed;
                Console.WriteLine($"Le film {moviesListResult[0].Title} a été supprimé !!");
            }
            else
            {
                Console.WriteLine($"Votre recherche comporte plusieurs résultats :");
                _writer.DisplayMovies(moviesListResult);
                var question = new Question("Entrer l'id du film à supprimer :", QuestionType.Numerique);
                _manager.WriteQuestion(question);
                var answer = _manager.ReadUserEntry(question);
                var movieToDelete = Movies.FirstOrDefault(m => m.IdC == int.Parse(answer.Text));
                var modifyedList = Movies as List<Movie>;
                modifyedList.Remove(movieToDelete);
                Movies = modifyedList;
                await _persistanceLogic.SaveMovies(Movies);
                Console.WriteLine($"Le film {movieToDelete.Title} a été supprimé !!");
            }
        }

        internal int CalculateId()
        {
            int id = 0;
            if (Movies.ToList().Count == 0)
            {
                return id = 1;
            }
            var lastMovie = Movies.Last();
            id = lastMovie.IdC + 1;
            return id;
        }
    }
}
