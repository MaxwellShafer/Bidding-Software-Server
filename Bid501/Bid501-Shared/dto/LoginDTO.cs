namespace Bid501_Shared
{
    public class LoginDTO : DTO<LoginDTO>
    {
        public const string Type = "LoginRequest";
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
