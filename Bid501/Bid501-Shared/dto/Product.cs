namespace Bid501_Shared
{
    public class Product : DTO<Product>
    {
        public const string Type = "Product";
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal MinBid { get; set; }
        public int BidCount { get; set; }
        public bool IsExpired { get; set; }

        public Product(string id, string name, decimal minBid, int bidCount, bool isExpired) 
        {
            Id = id;
            Name = name;
            MinBid = minBid;
            BidCount = bidCount;
            IsExpired = isExpired;
        }
    }
}