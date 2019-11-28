
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
    public class CityShoppingListViewModelTests
    {
       List<CityShopping> allMuseums { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            allMuseums = new List<CityShopping>();
            addMuseums();

        }

        

        public void addMuseums()
        {
            CityShopping CityShopping = new CityShopping()
            {
                CityShoppingID = 1,
                CityShoppingAddress = "Test Address 1",
                CityShoppingCategoryID = 1,
                BudgetID = 1,
                CityShoppingDescription = "Test Description",
                CityShoppingFavourite = true,
                CityShoppingImageURL = "http://testurl/url1.jpg",
                CityShoppingMapCoordinates = "100,100",
                CityShoppingName = "test shop one",
                ChildDetail = "test child detail",
                CityShoppingSubtext = "test subtext",
                CityShoppingTelephone = "123456789",
                CityShoppingWebSite = "testURL",
                DisabilityDetail = "disability detail test",
                TransportID = 2,
                NeighbourhoodID = 1

            };

            allMuseums.Add(CityShopping);

            CityShopping CityShopping2 = new CityShopping()
            {
                CityShoppingID = 2,
                DisabilityAccess = true

            };

            allMuseums.Add(CityShopping2);
            CityShopping CityShopping3 = new CityShopping()
            {
                CityShoppingID = 3,
                ChildFriendly = true

            };

            allMuseums.Add(CityShopping3);

        }



        [TestMethod]
       public void TestValuesSetForViewModel()
        {

            Mock<CityShoppingRepository> mock = new Mock<CityShoppingRepository>(null);
             mock.Setup(a => a.GetAllCityShops()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityShopsListViewModel mylv = new CityShopsListViewModel(mockNav.Object);


            var TestCount = mylv.returnCityShops(mock.Object);


          Assert.IsTrue(TestCount.Count() > 0);


        }


        [TestMethod]
        public void TestFavouriteFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityShoppingRepository> mock = new Mock<CityShoppingRepository>(null);
            mock.Setup(a => a.GetAllCityShops()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityShopsListViewModel mylv = new CityShopsListViewModel(mockNav.Object);


            mylv.SetCityShoppings(mock.Object.GetAllCityShops(), true);

            mylv.SetFavouriteFilter(mock.Object,true);


            int countafterset=  mylv.allCityShoppings.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
    

        [TestMethod]
        public void TestDisabilityFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityShoppingRepository> mock = new Mock<CityShoppingRepository>(null);
            mock.Setup(a => a.GetAllCityShops()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityShopsListViewModel mylv = new CityShopsListViewModel(mockNav.Object);


            mylv.SetCityShoppings(mock.Object.GetAllCityShops(), true);

            mylv.SetDisabledFilter(mock.Object, true);


            int countafterset = mylv.allCityShoppings.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestChildFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<CityShoppingRepository> mock = new Mock<CityShoppingRepository>(null);
            mock.Setup(a => a.GetAllCityShops()).Returns(allMuseums);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityShopsListViewModel mylv = new CityShopsListViewModel(mockNav.Object);


            mylv.SetCityShoppings(mock.Object.GetAllCityShops(), true);
            mylv.SetChildFilter(mock.Object, true);


            int countafterset = mylv.allCityShoppings.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
       
        

    }
}
