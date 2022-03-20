using LinkShortener.DTOs;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkShortener.Pages
{
    public class RegisterModel : PageModel
    {
        private IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(RegisterUserViewModel user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                ViewData["Error"] = "رمزهای عبور مطابقت ندارند";
                return Page();
            }

            if (_userService.DoesUserNameExist(user.UserName))
            {
                ViewData["Error"] = "این نام کاربری قبلا انتخاب شده است";
                return Page();
            }

            _userService.RegisterNewUser(new Model.User
            {
                UserName = user.UserName,
                Password = user.Password,
            });

            return RedirectToPage("/Index");
        }
    }
}
