using EbaySearcherModels.cs;
using EbaySearcherRepository.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySearcher.Bll
{
    public class EbaySearcherBll
    {
        public ICollection<Listing> SearhEbayListingsByKeyword(string keyword)
        {
            var searchEngine = new SearchEngine();
            return searchEngine.SearchByKeyword(keyword);
        }
    }
}
