using EbaySearcher.Bll;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EbaySearcher.Controllers
{
    public class DataServiceController : Controller
    {
        private IEbaySearcherBll _EbaySearcherBll;
        public DataServiceController(): this(null) { }
        public DataServiceController(IEbaySearcherBll ebaySearcherBll)
        {
            _EbaySearcherBll = ebaySearcherBll ?? new EbaySearcherBll();
        }
        public JsonResult SearchEbayListingsByKeyword(string keyword, int maxSearchResults)
        {            
            var searchResults = _EbaySearcherBll.SearchEbayListingsByKeyword(keyword, maxSearchResults);
            var serializedSearchResults = new JavaScriptSerializer().Serialize(searchResults);
            return Json(serializedSearchResults, JsonRequestBehavior.AllowGet);
        }
    }
}