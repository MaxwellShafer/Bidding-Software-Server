namespace Bid501_Client
{
    public class LoginDTO : DTO<LoginDTO>
    {
        public static string Type = "LoginRequest";
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
