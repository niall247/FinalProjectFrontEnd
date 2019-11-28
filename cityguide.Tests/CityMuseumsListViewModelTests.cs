
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
    public class CityMuseumstListViewModelTests
    {
       List<CityMuseum> allMuseums { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            allMuseums = new List<CityMuseum>();
            addMuseums();

        }

        

        public void addMuseums()
        {
            CityMuseum CityMuseum = new CityMuseum()
            {
                CityMuseumID = 1,
                CityMuseumAddress = "Test Address 1",
                CityMuseumCategoryID = 1,
                CityMuseumCost = "10 EUR",
                CityMuseumDescription = "Test Description",
                CityMuseumFavourite = true,
                CityMuseumImageURL = "http://testurl/url1.jpg",
                CityMuseumMapCoordinates = "100,100",
                CityMuseumName = "test site one",
                ChildDetail = "test child detail",
                CityMuseumSubtext = "test subtext",
                CityMuseumTelephone = "123456789",
                CityMuseumWebSite = "testURL",
                DisabilityDetail = "disability detail test",
                TransportID = 2,
                NeighbourhoodID = 1

            };

            allMuseums.Add(CityMuseum);

            CityMuseum CityMuseum2 = new CityMuseum()
            {
                CityMuseumID = 2,
                DisabilityAccess = true

            };

            allMuseums.Add(CityMuseum2);
            CityMuseum CityMuseum3 = new CityMuseum()
            {
                CityMuseumID = 3,
                ChildFriendly = true

            };

            allMuseums.Add(CityMuseum3);

        }



        [TestMethod]
       public void TestValuesSetForViewModel()
        {

            Mock<CityMuseumRepository> mock = new Mock<CityMuseumRepository>(null);
             mock.Setup(a => a.GetAllCityMuseums()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityMuseumsListViewModel mylv = new CityMuseumsListViewModel(mockNav.Object);


            var TestCount = mylv.returnCityMuseums(mock.Object);


          Assert.IsTrue(TestCount.Count() > 0);


        }


        [TestMethod]
        public void TestFavouriteFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityMuseumRepository> mock = new Mock<CityMuseumRepository>(null);
            mock.Setup(a => a.GetAllCityMuseums()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityMuseumsListViewModel mylv = new CityMuseumsListViewModel(mockNav.Object);


            mylv.SetCityMuseums(mock.Object.GetAllCityMuseums(), true);

            mylv.SetFavouriteFilter(mock.Object,true);


            int countafterset=  mylv.allCityMuseums.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
    

        [TestMethod]
        public void TestDisabilityFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityMuseumRepository> mock = new Mock<CityMuseumRepository>(null);
            mock.Setup(a => a.GetAllCityMuseums()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityMuseumsListViewModel mylv = new CityMuseumsListViewModel(mockNav.Object);


            mylv.SetCityMuseums(mock.Object.GetAllCityMuseums(), true);

            mylv.SetDisabledFilter(mock.Object, true);


            int countafterset = mylv.allCityMuseums.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestChildFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityMuseumRepository> mock = new Mock<CityMuseumRepository>(null);
            mock.Setup(a => a.GetAllCityMuseums()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityMuseumsListViewModel mylv = new CityMuseumsListViewModel(mockNav.Object);


            mylv.SetCityMuseums(mock.Object.GetAllCityMuseums(), true);
            mylv.SetChildFilter(mock.Object, true);


            int countafterset = mylv.allCityMuseums.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
       
        

    }
}
