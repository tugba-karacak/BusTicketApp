using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interfaces
{
    // 3 tane güzergah Ankara-İstanbul, Hatay-İstanbul, Gaziantep-Hatay
    // 
    public interface IApplicationUserService :IGenericService<ApplicationUser>
    {
        ApplicationUser CheckUser(string email, string password);

        /// <summary>
        ///  Eğer sistemde ilgili email var ise true döner yoksa false
        /// </summary>
        /// <param name="email">Email parametresi</param>
        /// <returns></returns>
        bool CheckEmail(string email);
    }
}
