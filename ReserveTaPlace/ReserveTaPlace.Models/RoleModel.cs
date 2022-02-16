using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class RoleModel
    {
        private Guid _id;
        private string _name;

        public RoleModel(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
        }

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
