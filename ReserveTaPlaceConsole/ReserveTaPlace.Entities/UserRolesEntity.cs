using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    internal class UserRolesEntity
    {
        public enum UserRoles
        {
            Client,
            AdminLocal,
            AdminGroupe,
            AdminGlobal
        }
    }
}
