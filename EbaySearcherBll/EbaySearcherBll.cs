using EbaySearcher.Models;
using EbaySearcher.Repository;
using System.Collections.Generic;
using System.Linq;


namespace EbaySearcher.Bll
{
    public class EbaySearcherBll : IEbaySearcherBll
    {
        private ISearchEngine _SearchEngine;
        public EbaySearcherBll() : this(null) { }
        public EbaySearcherBll(ISearchEngine searchEngine)
        {
            _SearchEngine = searchEngine ?? new SearchEngine();
        }
        public ICollection<SearchResult> SearchEbayListingsByKeyword(string keyword, int maxResults)
        {
            var listings = _SearchEngine.SearchByKeyword(keyword, maxResults);
            var searchResults = listings.GroupBy(t => new { CategoryName = t.CategoryName })
                                .Select(g => new SearchResult
                                {
                                    CountByCategory = g.Count(),
                                    AveragePrice = g.Average(p => p.CurrentPrice),
                                    CategoryName = g.Key.CategoryName
                                }).ToList();

            return searchResults;
        }


    }
}
