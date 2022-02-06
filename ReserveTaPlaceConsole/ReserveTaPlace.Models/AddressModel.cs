using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class AddressModel
    {
        private Guid _id;
        private string _address1;
        private string _address2;
        private string _street;
        private string _city;
        private string _postalCode;
        private string _number;
        private string _county;
        private TheaterModel _theater;

        public AddressModel(string address1, string address2, string street, string city, string postalCode, string number, string county, TheaterModel theater)
        {
            _id = Guid.NewGuid();
            _address1 = address1;
            _address2 = address2;
            _street = street;
            _city = city;
            _postalCode = postalCode;
            _number = number;
            _county = county;
            _theater = theater;
        }

        public Guid Id { get => _id; }
        public string Address1 { get { return _address1; }set { _address1 = value; } }
        public string Address2 { get { return _address2; }set { _address2 = value; } }
        public string Street { get { return _street; }set { _street = value; } }
        public string City { get { return _city; }set { _city = value; } }
        public string PostalCode { get { return _postalCode; }set { _postalCode = value; } }
        public string Number { get { return _number; }set { _number = value; } }
        public string County { get { return _county; }set { _county = value; } }
        public TheaterModel Theater { get { return _theater; }set { _theater = value; } }

    }
}
