namespace Bid501_Shared
{
    public class LoginDTO : DTO<LoginDTO>
    {
        public const string SerializeType = "LoginRequest";

        /// <summary>
        /// The type string for data processing
        /// </summary>
        public string Type => SerializeType;

        public string Username { get; set; }
        public string Password { get; set; }
    }
}