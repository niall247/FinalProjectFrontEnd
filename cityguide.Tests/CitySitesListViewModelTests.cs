
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cityguide;
using cityguide.Data;
using cityguide.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using cityguide.Domain;
using System.Linq;
using System;
using cityguide.Converters;
using Moq;
using cityguide.ViewModels;

namespace cityguide.Tests.TestResults
{
    [TestClass]
    public class CitySitestListViewModelTests
    {
       List<CitySite> allSites { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            allSites = new List<CitySite>();
            addSites();

        }

        

        public void addSites()
        {
            CitySite citySite = new CitySite()
            {
                CitySiteID = 1,
                CitySiteAddress = "Test Address 1",
                CitySiteCategoryID = 1,
                CitySiteCost = "10 EUR",
                CitySiteDescription = "Test Description",
                CitySiteFavourite = true,
                CitySiteImageURL = "http://testurl/url1.jpg",
                CitySiteMapCoordinates = "100,100",
                CitySiteName = "test site one",
                ChildDetail = "test child detail",
                CitySiteSubtext = "test subtext",
                CitySiteTelephone = "123456789",
                CitySiteWebSite = "testURL",
                DisabilityDetail = "disability detail test",
                TransportID = 2,
                NeighbourhoodID = 1

            };

            allSites.Add(citySite);

            CitySite citySite2 = new CitySite()
            {
                CitySiteID = 2,
                DisabilityAccess = true

            };

            allSites.Add(citySite2);
            CitySite citySite3 = new CitySite()
            {
                CitySiteID = 3,
                ChildFriendly = true

            };

            allSites.Add(citySite3);

        }



        [TestMethod]
       public void TestValuesSetForViewModel()
        {

            Mock<CitySiteRepository> mock = new Mock<CitySiteRepository>(null);
             mock.Setup(a => a.GetAllCitySites()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CitySitesListViewModel mylv = new CitySitesListViewModel(mockNav.Object);


            var TestCount = mylv.returnCitySites(mock.Object);


          Assert.IsTrue(TestCount.Count() > 0);


        }


        [TestMethod]
        public void TestFavouriteFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CitySiteRepository> mock = new Mock<CitySiteRepository>(null);
            mock.Setup(a => a.GetAllCitySites()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CitySitesListViewModel mylv = new CitySitesListViewModel(mockNav.Object);


            mylv.SetCitySites(mock.Object.GetAllCitySites(), true);

            mylv.SetFavouriteFilter(mock.Object,true);


            int countafterset=  mylv.allCitySites.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
    

        [TestMethod]
        public void TestDisabilityFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CitySiteRepository> mock = new Mock<CitySiteRepository>(null);
            mock.Setup(a => a.GetAllCitySites()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CitySitesListViewModel mylv = new CitySitesListViewModel(mockNav.Object);


            mylv.SetCitySites(mock.Object.GetAllCitySites(), true);

            mylv.SetDisabledFilter(mock.Object, true);


            int countafterset = mylv.allCitySites.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestChildFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CitySiteRepository> mock = new Mock<CitySiteRepository>(null);
            mock.Setup(a => a.GetAllCitySites()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CitySitesListViewModel mylv = new CitySitesListViewModel(mockNav.Object);


            mylv.SetCitySites(mock.Object.GetAllCitySites(), true);
            mylv.SetChildFilter(mock.Object, true);


            int countafterset = mylv.allCitySites.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
       
        

    }
}
