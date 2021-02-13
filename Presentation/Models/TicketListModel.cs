using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class TicketListModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int SeatNumber { get; set; }

        public decimal Price { get; set; }

        public Bus Bus { get; set; }

        public Location Location { get; set; }

        public int VoyageId { get; set; }
    }
}
