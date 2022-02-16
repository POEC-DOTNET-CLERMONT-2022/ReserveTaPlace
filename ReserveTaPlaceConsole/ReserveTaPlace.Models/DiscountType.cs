using System;

namespace ReserveTaPlace.Models
{
    internal class DiscountType
    {
        private Guid _id;
        private string _name;
        private string _description;
        private uint? _rate;
        private decimal? _amount;

        public DiscountType(string name, string description, uint? rate, decimal? amount)
        {
            _id = Guid.NewGuid();
            _name = name;
            _description = description;
            _rate = rate;
            _amount = amount;
        }
        public Guid Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }

        //TODO : pas besoin ? 
        public uint? Rate { get { return _rate; } }
        public decimal? Amount { get { return _amount; } }

    }
}
