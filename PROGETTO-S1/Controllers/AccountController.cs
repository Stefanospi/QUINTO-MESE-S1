using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PROGETTO_S1.Models;
using PROGETTO_S1.Service;
using System.Security.Claims;

namespace PROGETTO_S1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAuthService authService, ILogger<AccountController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users users)
        {
            try
            {
                var user = _authService.Login(users.username, users.password);
                if (user == null) {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return RedirectToAction("Index","Home");
                }

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username)
                };
                var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Register(Users users)
        {             
            try
            {
                var user = _authService.Register(users.username, users.password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                    return RedirectToAction("Index", "Home");
                }

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(ClaimTypes.Authentication,user.password)
                };
                var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
    }
}
