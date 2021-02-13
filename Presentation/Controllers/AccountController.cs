using Bussiness.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenericService<Role> _genericRoleService;
        private readonly IApplicationUserService _userService;

        public AccountController(IGenericService<Role> genericRoleService, IApplicationUserService userService)
        {
            _genericRoleService = genericRoleService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user= _userService.CheckUser(model.Email, model.Password);
                if (user != null)
                {
                    var claims = new List<Claim>();

                    var role= _genericRoleService.GetById(user.RoleId);
                    
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));

                    claims.Add(new Claim(ClaimTypes.Name, user.Name + " " + user.Surname));

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity)
                        );

                    if (role.Id == 2)
                    {
                        return RedirectToAction("Index", "Voyage");
                    }
                    if (role.Id == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
             
            }

          

            return View(model);

        }

        public IActionResult Register()
        {
            return View(new UserRegisterModel());
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var emailControl= _userService.CheckEmail(model.Email);

                if (!emailControl)
                {
                    _userService.Create(new ApplicationUser
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Password = model.Password,
                        RoleId = 2,
                        Surname = model.Surname
                    });
                
                    return RedirectToAction("Login","Account");

                }
                ModelState.AddModelError("", "Email adresi zaten sistemde kayıtlı");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
