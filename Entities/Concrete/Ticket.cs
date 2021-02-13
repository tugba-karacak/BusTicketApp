using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Ticket : ITable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int SeatNumber { get; set; }

        public decimal Price { get; set; }

        public int VoyageId { get; set; }


        public Voyage Voyage { get; set; }
    }
}
