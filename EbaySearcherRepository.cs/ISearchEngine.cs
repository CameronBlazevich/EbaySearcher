
using EbaySearcher.Models;
using System.Collections.Generic;

namespace EbaySearcher.Repository
{
    public interface ISearchEngine
    {
        ICollection<Listing> SearchByKeyword(string keyword, int maxResults);
    }
}
