using Data.Concrete.EntityFrameworkCore.Context;
using Data.Interfaces;
using Entities.Concrete;

namespace Data.Concrete.EntityFrameworkCore.Repositories
{
    public class RoleDalEf : GenericDalEf<Role>, IRoleDal
    {
        public RoleDalEf(BusContext context) : base(context)
        {
        }
    }
}
