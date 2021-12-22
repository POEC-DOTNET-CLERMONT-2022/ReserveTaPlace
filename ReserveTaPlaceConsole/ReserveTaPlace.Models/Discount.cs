using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    internal class Discount
    {
        private Guid _id;
        private DiscountType _discountType;

        public Discount(DiscountType discountType)
        {
            _id = Guid.NewGuid();
            _discountType = discountType;
        }
        public Guid Id { get { return _id; } }
        public DiscountType DiscountType { get { return _discountType; } }
    }
}
