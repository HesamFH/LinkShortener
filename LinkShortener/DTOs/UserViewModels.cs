namespace LinkShortener.DTOs
{
    public class RegisterUserViewModel
    {
        public string? UserName { get; set;}

        public string? Password { get; set;}

        public string? ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        public string? UserName { get; set;}

        public string? Password { get; set;}
    }
}
