using System.Text.Json;

namespace Bid501_Shared
{
    /// <summary>
    /// Base Data Transfer Object (DTO) class to handle our JSON serialization and deserialization
    /// </summary>
    /// <typeparam name="T">T should be the name of the class (i.e. MyData : DTO<MyData>)</typeparam>
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