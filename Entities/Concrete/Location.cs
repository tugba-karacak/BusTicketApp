using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Location : ITable
    {
        public int Id { get; set; }
        public string Source { get; set; }

        public string Target { get; set; }

        public decimal StandartPrice { get; set; }

        public List<Voyage> Voyages { get; set; }
    }
}
