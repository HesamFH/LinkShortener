using LinkShortener.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LinkShortener.Model;
using LinkShortener.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace LinkShortener.Pages
{
    public class LoginModel : PageModel
    {
        private IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnPostAsync(LoginViewModel user)
        {
            User _user = _userService.GetUser(user.UserName, user.Password);
            if (_user != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, _user.UserId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, _user.UserName!),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                return Redirect("/links");
            }
            ViewData["Error"] = "نام کاربری یا کلمه عبور غلط است";

            return Page();
        }
    }
}
