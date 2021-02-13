using Bussiness.Interfaces;
using Data.Concrete.EntityFrameworkCore;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class ApplicationUserManager : GenericManager<ApplicationUser>, IApplicationUserService
    {
        private readonly IGenericDal<ApplicationUser> _genericDal;
        public ApplicationUserManager(IGenericDal<ApplicationUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public bool CheckEmail(string email)
        {
            return _genericDal.GetByFilter(a => a.Email == email) != null;
        }

        public ApplicationUser CheckUser(string email, string password)
        {
            return _genericDal.GetByFilter(a => a.Email == email && a.Password == password);
        }
    }
}
