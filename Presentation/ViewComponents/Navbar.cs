using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewComponents
{
    public class Navbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var control = User.Identity.IsAuthenticated;
            if (control)
            {
                ViewBag.IsAdmin = User.IsInRole("Admin");
                ViewBag.IsMember = User.IsInRole("Member");
            }
            ViewBag.Control = control;
            return View();
        }
    }
}
