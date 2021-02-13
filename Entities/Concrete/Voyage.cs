using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Voyage : ITable
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int BusId { get; set; }

        public Bus Bus { get; set; }
      
        public DateTime VoyageDate { get; set; }

        public List<Ticket> Tickets { get; set; }

        [NotMapped]

        public  int FreeSeatCount { get; set; }

    }
}
