namespace Bid501_Shared
{
    public class ProductDTO : DTO<ProductDTO>
    {
        public const string SerializeType = "Product";

        /// <summary>
        /// The type string for data processing
        /// </summary>
        public string Type => SerializeType;

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal MinBid { get; set; }
        public int BidCount { get; set; }
        public bool IsExpired { get; set; }
    }
}