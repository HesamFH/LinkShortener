using LinkShortener.Model;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkShortener.Pages
{
    [Authorize]
    public class LinksModel : PageModel
    {
        private ILinkService _linkService;

        public LinksModel(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public void OnGet()
        {
            List<Links> links = _linkService.GetUserLinks(int.Parse(User.Identity.Name));
            ViewData["Links"] = links;
        }
    }
}
