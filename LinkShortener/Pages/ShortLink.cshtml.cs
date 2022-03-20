using LinkShortener.Model;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkShortener.Pages
{
    public class ShortLinkModel : PageModel
    {
        private ILinkService _linkService;

        public ShortLinkModel(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string longLink)
        {
            if (longLink == null)
            {
                return Page();
            }
            else
            {
                var shortLink = _linkService.AddLink(new Links
                {
                    ActualLink = longLink,
                    ShortenedLink = Guid.NewGuid().ToString().Substring(0, 5),
                    UserId = int.Parse(User.Identity.Name)
                });

                ViewData["Link"] = shortLink;
                return Page();
            }
        }
    }
}
