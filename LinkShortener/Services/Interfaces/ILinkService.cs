using LinkShortener.Model;

namespace LinkShortener.Services.Interfaces
{
    public interface ILinkService
    {
        public string? AddLink(Links link);

        public string? GetLink(string shortenedLink);

        public List<Links> GetUserLinks(int userId);
    }
}
