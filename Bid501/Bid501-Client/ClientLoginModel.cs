using System.Text.Json;

namespace Bid501_Client
{
    public class ClientLoginModel
    {
        public string Type = "LoginRequest";
        public string Username { get; set; }
        public string Password { get; set; }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
