using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        #region Relations

        public List<Links>? Links { get; set; }

        #endregion
    }
}
