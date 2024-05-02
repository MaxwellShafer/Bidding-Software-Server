using System.Text.Json;

namespace Bid501_Shared
{
    public class DTO<T> where T : class
    {
        public string Serialize()
        {
            return JsonSerializer.Serialize<T>(this as T);
        }
        
        public static T Deserialize(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}