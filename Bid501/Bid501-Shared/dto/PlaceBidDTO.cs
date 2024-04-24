namespace Bid501_Shared
{
    public class PlaceBidDTO : DTO<PlaceBidDTO>
    {
        public const string Type = "PlaceBidRequest";
        public string Id { get; set; }
        public decimal Bid { get; set; }
    }
}