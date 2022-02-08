using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class UserTheater
    {
        public Guid UserId { get; set; }
        public Guid TheaterId { get; set; }
        public UserDto User { get; set; }
        public TheaterDto Theater { get; set; }
    }
}
