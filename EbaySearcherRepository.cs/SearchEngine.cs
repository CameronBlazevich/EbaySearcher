using EbaySearcher.FindingServiceReference;
using EbaySearcher.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Configuration;

namespace EbaySearcher.Repository
{
    public class SearchEngine : ISearchEngine
    {
        public ICollection<Listing> SearchByKeyword(string keyword, int maxResults)
        {
            using (FindingServicePortTypeClient client = new FindingServicePortTypeClient())

            {

                MessageHeader header = MessageHeader.CreateHeader("CustomHeader", "", "");

                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))

                {                                     
                    string appName = ConfigurationManager.AppSettings["EbayAppName"];

                    OperationContext.Current.OutgoingMessageHeaders.Add(header);

                    HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();

                    httpRequestProperty.Headers.Add("X-EBAY-SOA-SECURITY-APPNAME", appName);

                    httpRequestProperty.Headers.Add("X-EBAY-SOA-OPERATION-NAME", "findItemsByKeywords");

                    httpRequestProperty.Headers.Add("X-EBAY-SOA-GLOBAL-ID", "EBAY-US");

                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    FindItemsByKeywordsRequest request = new FindItemsByKeywordsRequest();
                    request.keywords = keyword;

                    PaginationInput paginationInput = new PaginationInput();
                    var listings = new List<Listing>();
                    var maxEntriesPerPage = 100;
                    var maxIterations = maxResults / maxEntriesPerPage;
                    paginationInput.entriesPerPage = maxEntriesPerPage;

                    for (var i = 0; i < maxIterations; i++)
                    {                     
                        paginationInput.pageNumber = i;                       
                        
                        request.paginationInput = paginationInput;

                        FindItemsByKeywordsResponse response = client.findItemsByKeywords(request);
                      
                        if (response?.searchResult?.item == null || response.ack.ToString() != "Success")
                            return listings;

                        var results = response.searchResult.item;

                        foreach (var result in results)
                        {
                            var listing = MapResultToListing(result);
                            listings.Add(listing);
                        }
                        
                        if (response.searchResult.count < maxEntriesPerPage)
                            break;
                    }
                    return listings;
                }
            }
        }
        private Listing MapResultToListing(SearchItem result)
        {
            var listing = new Listing();
            listing.CurrentPrice = result.sellingStatus.currentPrice.Value;
            listing.ItemId = result.itemId;
            listing.Title = result.title;
            listing.CategoryId = Convert.ToInt32(result.primaryCategory.categoryId);
            listing.CategoryName = result.primaryCategory.categoryName;
            
            return listing;
        }
    }
}
