using System.Text.Json;

namespace Bid501_Shared
{
    public class DTO<T>
    {
        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        
        public static T Deserialize(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}