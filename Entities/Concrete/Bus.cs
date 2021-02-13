using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Bus : ITable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Voyage> Voyages { get; set; }
    }
}
