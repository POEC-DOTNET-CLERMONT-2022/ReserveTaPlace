﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Calendar")]
    public class CalendarEntity
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(SessionId))]
        public virtual SessionEntity Session { set; get; }
    }
}
