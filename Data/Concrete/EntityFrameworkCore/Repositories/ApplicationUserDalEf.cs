using Common.Enums;
using Data.Concrete.EntityFrameworkCore.Context;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Concrete.EntityFrameworkCore.Repositories
{
    public class ApplicationUserDalEf : GenericDalEf<ApplicationUser>, IApplicationUserDal
    {
        public ApplicationUserDalEf(BusContext context) : base(context)
        {
        }
    }
}
