using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using EbaySearcherRepository.cs.EbaySearcher.FindingServiceReference;
using System.ServiceModel.Channels;

namespace EbaySearcherRepository.cs.Helpers
{
    public class RequestBuilder 
    {
        public static HttpRequestMessageProperty CreateNewApiCall()
        {
            HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();

            httpRequestProperty.Headers.Add("X-EBAY-SOA-SECURITY-APPNAME", "CameronB-EbayFeeT-PRD-e8a129233-5ff958d9");

            httpRequestProperty.Headers.Add("X-EBAY-SOA-OPERATION-NAME", "findItemsByKeywords");

            httpRequestProperty.Headers.Add("X-EBAY-SOA-GLOBAL-ID", "EBAY-US");

            return httpRequestProperty;
        }

        public static void CreateFindingApiCall()
        {
           // Find

        }

    }
}
