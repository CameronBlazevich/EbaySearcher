using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySearcherModels.cs
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
