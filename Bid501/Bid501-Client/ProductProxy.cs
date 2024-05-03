using System.Text;
using Bid501_Shared;

namespace Bid501_Client
{
    public class ProductProxy : ProductDTO
    {
        public ProductProxy(ProductDTO ch)
        {
            foreach (var prop in ch.GetType().GetProperties())
            {
                var targetProp = GetType().GetProperty(prop.Name);
                if (targetProp?.CanWrite == true)
                {
                    targetProp.SetValue(this, prop.GetValue(ch, null), null);
                }
            }
        }

        public bool IsWinning { get; set; } = false;
    }
}