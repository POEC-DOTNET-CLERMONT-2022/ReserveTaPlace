using ReserveTaPlace.wcf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ReserveTaPlace.wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MovieService : IMovieService
    {
        public List<Movie> GetAll()
        {
             List<Movie> movieList = new List<Movie>() {
                new Movie("Alien"),
                new Movie("Dune"),
                new Movie("Terminator"),
                new Movie("Iron Man"),
                new Movie("La vie d'Adèle"),
                new Movie("Matrix 4"),
                new Movie("Le dernier duel"),
                new Movie("Detective Pikachu")};
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
