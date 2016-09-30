using EbaySearcherModels.cs;
using EbaySearcherRepository.cs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using EbaySearcherRepository.cs.EbaySearcher.FindingServiceReference;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EbaySearcherRepository.cs
{
    public class SearchEngine
    {
        public ICollection<Listing> SearchByKeyword(string keyword)
        {
            //var client = new FindingServicePortTypeClient();
            //var context = RequestBuilder.CreateNewApiCall();
            //var call = new findItemsByKeywordsRequest1;

            //return new List<Listing>();


            using (FindingServicePortTypeClient client = new FindingServicePortTypeClient())

            {

                MessageHeader header = MessageHeader.CreateHeader("CustomHeader", "", "");

                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))

                {

                    OperationContext.Current.OutgoingMessageHeaders.Add(header);



                    HttpRequestMessageProperty httpRequestProperty = RequestBuilder.CreateNewApiCall();



                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;



                    FindItemsByKeywordsRequest request = new FindItemsByKeywordsRequest();

                    request.keywords = keyword;

                    FindItemsByKeywordsResponse response = client.findItemsByKeywords(request);

                    var listings = new List<Listing>();

                    if (response?.searchResult?.item == null || response.ack.ToString() != "Success")
                        return listings;

                    var results = response.searchResult.item;
                    
                    foreach(var result in results)
                    {
                        var listing = MapResultToListing(result);
                        listings.Add(listing);
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
