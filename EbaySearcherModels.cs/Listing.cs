namespace EbaySearcher.Models
{
    public class Listing
    {
        public string ItemId { get; set; }
        public string Title { get; set; }
        public double CurrentPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
