using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Model
{
    public class Links
    {
        [Key]
        public int LinkId { get; set; }

        [Required]
        public string? ActualLink { get; set; }

        [Required]
        public string? ShortenedLink { get; set; }

        public int Views { get; set; }

        public int UserId { get; set; }

        #region Relations

        public User? User { get; set; }

        #endregion
    }
}
