using CleanArchMvc.Domain.Accounts;
using CleanArchMvc.WebUI.Models;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class AccountsController(IAuthenticate authentication) : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel(returnUrl));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userLogin)
        {
            var result = await authentication.Login(userLogin.Email, userLogin.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(userLogin.ReturnUrl))
                    return RedirectToAction("Index", "Home");

                return Redirect(userLogin.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. (Password must be strong).");
                return View(userLogin);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var result = await authentication.Register(register.Email, register.Password);
            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt. (password must be strong)");
                return View(register);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authentication.Logout();
            return RedirectToAction("Login", "Accounts");
        }
    }
}
