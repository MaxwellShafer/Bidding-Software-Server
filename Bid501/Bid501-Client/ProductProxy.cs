using System.Text;
using Bid501_Shared;

namespace Bid501_Client
{
    public class ProductProxy : Product
    {
        public ProductProxy(Product ch)
        {
            foreach (var prop in ch.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name)?.SetValue(this, prop.GetValue(ch, null), null);
            }
        }

        public bool IsWinning { get; set; } = false;
    }
}