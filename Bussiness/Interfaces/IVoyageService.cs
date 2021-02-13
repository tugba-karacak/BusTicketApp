using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interfaces
{
    public interface IVoyageService : IGenericService<Voyage>
    {
        List<Voyage> GetVoyages(DateTime time, int locationId);
    }
}
