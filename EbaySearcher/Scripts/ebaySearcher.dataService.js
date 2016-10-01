var dataService = new function () {
    var serviceBase = '/DataService/',
        searchEbayListingsByKeyword = function (baseUrl, keyword, maxSearchResults, callback) {
            $.getJSON(baseUrl + serviceBase + 'SearchEbayListingsByKeyword', { keyword: keyword, maxSearchResults: maxSearchResults }, function (data) {
                callback(data);
            });
        };
    return {
        getEbayListingsByKeyword: searchEbayListingsByKeyword
    };
}();