namespace Bid501_Client
{
    public class PlaceBidDTO : DTO<PlaceBidDTO>
    {
        public string Type = "PlaceBidRequest";
        public string Id { get; set; }
        public decimal Bid { get; set; }
    }
}