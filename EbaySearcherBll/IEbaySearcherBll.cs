using EbaySearcher.Models;
using System.Collections.Generic;

namespace EbaySearcher.Bll
{
    public interface IEbaySearcherBll
    {
        ICollection<SearchResult> SearchEbayListingsByKeyword(string keyword, int maxResults);
    }
}
