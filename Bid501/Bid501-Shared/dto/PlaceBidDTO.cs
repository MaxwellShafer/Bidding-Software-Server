namespace Bid501_Shared
{
    public class PlaceBidDTO : DTO<PlaceBidDTO>
    {
        public const string SerializeType = "PlaceBidRequest";
        /// <summary>
        /// The type string for data processing
        /// </summary>
        public string Type => SerializeType;

        public string Id { get; set; }
        public decimal Bid { get; set; }
    }
}