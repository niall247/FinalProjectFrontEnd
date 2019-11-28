
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
    public class CityRestaurantstListViewModelTests
    {
       List<CityRestaurant> allSites { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            allSites = new List<CityRestaurant>();
            addSites();

        }

        

        public void addSites()
        {
            CityRestaurant CityRestaurant = new CityRestaurant()
            {
                CityRestaurantID = 1,
                CityRestaurantAddress = "Test Address 1",
                CuisineID = 1,
                BudgetID = 1,
           
                CityRestaurantDescription = "Test Description",
                CityRestaurantFavourite = true,
                CityRestaurantImageURL = "http://testurl/url1.jpg",
                CityRestaurantMapCoordinates = "100,100",
                CityRestaurantName = "test site one",
                ChildDetail = "test child detail",
                CityRestaurantSubtext = "test subtext",
                CityRestaurantTelephone = "123456789",
                CityRestaurantWebSite = "testURL",
                DisabilityDetail = "disability detail test",
                CityRestaurantOpeningHours = "10am-12am, Mon-Sun",
                TransportID = 2,
                NeighbourhoodID = 1

            };

            allSites.Add(CityRestaurant);

            CityRestaurant CityRestaurant2 = new CityRestaurant()
            {
                CityRestaurantID = 2,
                DisabilityAccess = true

            };

            allSites.Add(CityRestaurant2);
            CityRestaurant CityRestaurant3 = new CityRestaurant()
            {
                CityRestaurantID = 3,
                ChildFriendly = true

            };
            allSites.Add(CityRestaurant3);
            CityRestaurant CityRestaurant4 = new CityRestaurant()
            {
                CityRestaurantID = 4,
                GlutenFree = true

            };
            allSites.Add(CityRestaurant4);
            CityRestaurant CityRestaurant5 = new CityRestaurant()
            {
                CityRestaurantID = 5,
                Kosher = true

            };
            allSites.Add(CityRestaurant5);

            CityRestaurant CityRestaurant6 = new CityRestaurant()
            {
                CityRestaurantID = 6,
                Halal = true

            };

            allSites.Add(CityRestaurant6);
            CityRestaurant CityRestaurant7 = new CityRestaurant()
            {
                CityRestaurantID = 7,
                Vegetarian = true

            };
            allSites.Add(CityRestaurant7);


            CityRestaurant CityRestaurant8 = new CityRestaurant()
            {
                CityRestaurantID = 8,
                DairyFree = true

            };
            allSites.Add(CityRestaurant8);

            CityRestaurant CityRestaurant9 = new CityRestaurant()
            {
                CityRestaurantID = 9,
                Vegan = true

            };
            allSites.Add(CityRestaurant9);
        }



        [TestMethod]
       public void TestValuesSetForViewModel()
        {

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
             mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            var TestCount = mylv.returnCityRestaurants(mock.Object);


          Assert.IsTrue(TestCount.Count() > 0);


        }


        [TestMethod]
        public void TestFavouriteFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);

            mylv.SetFavouriteFilter(mock.Object,true);


            int countafterset=  mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
    

        [TestMethod]
        public void TestDisabilityFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);

            mylv.SetDisabledFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestChildFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);
            mylv.SetChildFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }


        [TestMethod]
        public void TestGFFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);
            mylv.SetGlutenFreeFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestkosherFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);
            mylv.SetKosherFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestVeganFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);
            mylv.SetVeganFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestVegetarianFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);
            mylv.SetVegetarianFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }


        [TestMethod]
        public void TestDFFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);
            mylv.SetDairyFreeFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }


        [TestMethod]
        public void TestHalalFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityRestaurantRepository> mock = new Mock<CityRestaurantRepository>(null);
            mock.Setup(a => a.GetAllCityRestaurants()).Returns(allSites);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityRestaurantsListViewModel mylv = new CityRestaurantsListViewModel(mockNav.Object);


            mylv.SetCityRestaurants(mock.Object.GetAllCityRestaurants(), true);
            mylv.SetHalalFilter(mock.Object, true);


            int countafterset = mylv.allCityRestaurants.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }


    }
}
