using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class FormatModel
    {
        private Guid _id;
        private string _name;

        public FormatModel(Guid id, string name)
        {
            _id = id;
            _name = name;
        }

        public Guid Id { get { return _id; } }
        public string Name { get { return _name; } set { _name = value; } }
    }
}
