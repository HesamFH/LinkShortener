using LinkShortener.Model.Context;
using LinkShortener.Services;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkShortener.Pages.link
{
    public class IndexModel : PageModel
    {
        private ILinkService _linkService;

        public IndexModel(ILinkService linkService)
        {
            _linkService = linkService;
        }


        public IActionResult OnGet(string link)
        {
            string redirectLink = _linkService.GetLink(link);

            if (link != null)
            {
                return Redirect(redirectLink);
            }

            return Page();
        }
    }
}
