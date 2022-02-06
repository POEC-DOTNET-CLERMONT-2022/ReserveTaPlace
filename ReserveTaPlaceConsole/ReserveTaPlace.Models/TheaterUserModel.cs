using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class TheaterUserModel
    {
        private Guid _theaterId;
        private Guid _userId;
        private TheaterModel _theater;
        private UserModel _user;

        public TheaterUserModel(Guid theaterId, Guid userId, TheaterModel theater, UserModel user)
        {
            _theaterId = theaterId;
            _userId = userId;
            _theater = theater;
            _user = user;
        }

        public Guid TheaterId { get { return _theaterId; } set { _theaterId = value; } }
        public Guid UserId { get { return _userId; } set { _userId = value; } }
        public TheaterModel Theater { get { return _theater; } set { _theater = value; } }
        public UserModel User { get { return _user; } set { _user = value; } }
    }
}
