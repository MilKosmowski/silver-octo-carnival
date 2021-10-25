using System;

using CustomExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SearchWindow.Tests
{
    [TestClass()]
    public class InputValueExcTests
    {
        [TestMethod()]
        public void IsLocationExcTest()
        {
            Assert.ThrowsException<Exception>(() => MyExtensions.IsLocationExc("invalid location name"));
        }

        [TestMethod()]
        public void IsNumberExcTest()
        {
            Assert.ThrowsException<Exception>(() => MyExtensions.IsNumberExc("nieliczbowa wartosc"));
        }

        [TestMethod()]
        public void IsNotEmptyExcTest()
        {
            Assert.ThrowsException<Exception>(() => MyExtensions.IsNotEmptyExc(""));
        }

        [TestMethod()]
        public void IsNotZeroExcTest()
        {
            Assert.ThrowsException<Exception>(() => MyExtensions.IsNotZeroExc(0));
        }

        [TestMethod()]
        public void IsGreaterOrEqualThanZeroExc()
        {
            Assert.ThrowsException<Exception>(() => MyExtensions.IsGreaterOrEqualThanZeroExc(-1));
        }
    }

    [TestClass()]
    public class SearchWindowModelTests
    {
        [TestMethod()]
        public void WhatToLookForEmptyTest()
        {
            Assert.ThrowsException<Exception>(() => new SearchWindowModel("", "_sourceLocation", "_destinationLocation"));
        }

        [TestMethod()]
        public void SourceLocationEmptyTest()
        {
            Assert.ThrowsException<Exception>(() => new SearchWindowModel("_whatToLookFor", "", "_destinationLocation"));
        }

        [TestMethod()]
        public void DestinationLocationEmptyTest()
        {
            Assert.ThrowsException<Exception>(() => new SearchWindowModel("_whatToLookFor", "_sourceLocation", ""));
        }

        [TestMethod()]
        public void LineToCheckIsZeroTest()
        {
            Assert.ThrowsException<Exception>(() => new SearchWindowModel("_whatToLookFor", "_sourceLocation", "_sourceLocation", 0));
        }
    }
}