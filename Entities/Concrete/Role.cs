
using Entities.Interfaces;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Role : ITable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
