using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels
{
    public class RowModel
    {
        public string RowLetter { get; set; }
        public string TotalSeat { get; set; }
        public List<string> RowLetters = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P","Q" };

    }
}
