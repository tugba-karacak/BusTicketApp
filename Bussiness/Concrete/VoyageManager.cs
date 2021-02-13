using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class VoyageManager : GenericManager<Voyage>, IVoyageService
    {
        private readonly IGenericDal<Voyage> _genericDal;
        public VoyageManager(IGenericDal<Voyage> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public List<Voyage> GetVoyages(DateTime time, int locationId)
        {
            return _genericDal.GetAll(a => a.VoyageDate == time && a.LocationId == locationId);
        }
    }
}
