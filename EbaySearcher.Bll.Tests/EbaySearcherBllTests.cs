﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EbaySearcher.Models;
using EbaySearcher.Repository;
using Moq;
using System.Linq;

namespace EbaySearcher.Bll.Tests
{
    [TestClass]
    public class EbaySearcherBllTests
    {


        [TestMethod]
        public void SearchEbayListingsByKeyword_Successful()
        {
            //This is somewhat of a silly unit test, but illustrates utilizing static class

            //Arrange
            var searchTerm = "Harry Potter";
            var maxResults = 100;
            var listings = EbaySearcherBllTestsHelpers.SetUpSuccessfulBllTest();
            var mockSearchEngine = new Mock<ISearchEngine>();
            mockSearchEngine.Setup(x => x.SearchByKeyword(searchTerm, maxResults)).Returns(listings);

            var ebaySearcherBll = new EbaySearcherBll(mockSearchEngine.Object);

            var expected = listings.GroupBy(t => new { CategoryName = t.CategoryName })
                               .Select(g => new SearchResult
                               {
                                   CountByCategory = g.Count(),
                                   AveragePrice = g.Average(p => p.CurrentPrice),
                                   CategoryName = g.Key.CategoryName
                               }).ToList();

            //Act
            var actual = ebaySearcherBll.SearchEbayListingsByKeyword(searchTerm, maxResults);

            //Assert
            AssertHelper.HasEqualPropertyValues(expected, actual);
        }
    }
}