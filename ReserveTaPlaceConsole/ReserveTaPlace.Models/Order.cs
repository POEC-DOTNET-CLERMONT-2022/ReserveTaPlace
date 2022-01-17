using System;
using System.Collections.Generic;

namespace ReserveTaPlace.Models
{
    internal class Order
    {
        private Guid _id;
        private List<Ticket> _ticket;
        private DateTime _date;
        private User _user;

        public Order(List<Ticket> tickets, User user)
        {
            _id = Guid.NewGuid();
            _ticket = tickets;
            _date = DateTime.Now;
            _user = user;
        }

        public Guid Id { get { return _id; } }
        public List<Ticket> Ticket { get { return _ticket; } }
        public DateTime Date { get { return _date; } }
        public User User { get { return _user; } }
    }
}
