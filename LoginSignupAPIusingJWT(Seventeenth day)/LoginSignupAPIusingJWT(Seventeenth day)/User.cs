namespace LoginSignupAPIusingJWT_Seventeenth_day_
{
    public class User
    {
        public string Email { get; set; } = "";

        public byte[]? PasswordHash { get; set; } 

        public byte[]? PasswordSalt { get; set; }

        public string? Roles { get; set; }

    }
}

