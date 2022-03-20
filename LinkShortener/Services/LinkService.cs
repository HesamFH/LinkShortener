using LinkShortener.Model;
using LinkShortener.Model.Context;
using LinkShortener.Services.Interfaces;

namespace LinkShortener.Services
{
    public class LinkService : ILinkService
    {
        private LinkShortenerContext _context;
        private IUserService _userService;

        public LinkService(LinkShortenerContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        public string? AddLink(Links link)
        {
            _context.Links.Add(link);
            _context.SaveChanges();

            return link.ShortenedLink;
        }

        public string? GetLink(string shortenedLink)
        {
            if (shortenedLink != null)
            {
                var link = _context.Links.SingleOrDefault(l => l.ShortenedLink == shortenedLink)!;

                link.Views += 1;
                _context.SaveChanges();

                return link.ActualLink;
            } else
            {
                return "Not Ok";
            }
        }

        public List<Links> GetUserLinks(int userId)
        {
            return _context.Links.Where(l => l.UserId == userId).ToList();
        }
    }
}
