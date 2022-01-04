using ReserveTaPlace.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MovieService : IMovieService
    {
        public List<MovieDto> GetAllMovies()
        {
             List<MovieDto> movieList = new List<MovieDto>() {
                new MovieDto("Alien"),
                new MovieDto("Dune"),
                new MovieDto("Terminator"),
                new MovieDto("Iron Man"),
                new MovieDto("La vie d'Adèle"),
                new MovieDto("Matrix 4"),
                new MovieDto("Le dernier duel"),
                new MovieDto("Detective Pikachu")};

            return movieList;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
