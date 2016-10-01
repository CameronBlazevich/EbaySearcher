using EbaySearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySearcher.Bll.Tests
{
    public class EbaySearcherBllTestsHelpers
    {
        public static ICollection<Listing> SetUpSuccessfulBllTest()
        {
            var listings = new List<Listing>();
            for (var i = 0; i < 11; i++)
            {
                var listing = new Listing();

                if (i % 2 == 0)
                {
                    listing.CategoryId = 12345;
                    listing.CategoryName = "Books";
                }
                else
                {
                    listing.CategoryId = 12343;
                    listing.CategoryName = "Dvd";
                }
                listing.CurrentPrice = 5 + i;
                listing.ItemId = (12346798 + i).ToString();
                listing.Title = "Harry Potter " + i.ToString();
                listings.Add(listing);
            }
            return listings;
        }

    }
}
