var dataService = new function () {
    var serviceBase = '/DataService/',
        searchEbayListingsByKeyword = function (keyword, maxResults, callback) {
            $.getJSON(serviceBase + 'SearchEbayListingsByKeyword', { keyword: keyword, maxResults : maxResults }, function (data) {
                callback(data);
            });
        };
    return {
        getEbayListingsByKeyword: searchEbayListingsByKeyword
    };
}