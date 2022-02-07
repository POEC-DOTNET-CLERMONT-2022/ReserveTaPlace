using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class RoleModel
    {
        public RoleModel(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
        }
        private Guid _id;

        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
