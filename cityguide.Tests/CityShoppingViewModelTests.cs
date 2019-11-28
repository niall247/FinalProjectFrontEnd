
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
    public class CityShoppingViewModelTests
    {
       CityShopping selectedCityShopping { get; set; }

      CityShopViewModel cityVM { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            selectedCityShopping = new CityShopping()
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


        
            Mock<INavigation> mockNav = new Mock<INavigation>();

            cityVM = new CityShopViewModel(mockNav.Object, true);
            cityVM.SetDetails(selectedCityShopping);



        }





        [TestMethod]
       public void CityIDIsSetinViewmodel()
        {
            int valueToTest = 1;
            Assert.IsTrue(cityVM.CityShopID == valueToTest);
        }

        [TestMethod]
        public void CityNameIsSetinViewmodel()
        {
            string valuetoTest = "test shop one";
            Assert.IsTrue(cityVM.CityShopName == valuetoTest);
        }


        [TestMethod]
        public void CityNeighbourhoodsSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.NeighbourhoodID == valuetoTest);
        }

        [TestMethod]
        public void CityShoppingCategoryIDSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.CityShopCategoryID == valuetoTest);
        }

        [TestMethod]
        public void CityshopTransportIDSetinViewmodel()
        {
            int valuetoTest = 2;
            Assert.IsTrue(cityVM.TransportID == valuetoTest);
        }


        [TestMethod]
        public void CityShoppingBudgetetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.BudgetID == valuetoTest);
        }

        [TestMethod]
        public void CityChildDetailSetinViewmodel()
        {
            string valuetoTest = "test child detail";
            Assert.IsTrue(cityVM.ChildDetail == valuetoTest);
        }

        [TestMethod]
        public void CityDisabilityDetailSetinViewmodel()
        {
            string valuetoTest = "disability detail test";
            Assert.IsTrue(cityVM.DisabilityDetail == valuetoTest);
        }

        [TestMethod]
        public void CityAddresssetinViewmodel()
        {
            string valuetoTest = "Test Address 1";
            Assert.IsTrue(cityVM.CityShopAddress == valuetoTest);
        }

        [TestMethod]
        public void CityShoppingDescriptionsetinViewmodel()
        {
            string valuetoTest = "Test Description";
            Assert.IsTrue(cityVM.CityShopDescription == valuetoTest);
        }

       

        [TestMethod]
        public void CityShoppingMapCoordssetinViewmodel()
        {
            string valuetoTest = "100,100";
            Assert.IsTrue(cityVM.CityShopMapCoordinates == valuetoTest);
        }

        [TestMethod]
        public void CityShoppingSubTextsetinViewmodel()
        {
            string valuetoTest = "test subtext";
            Assert.IsTrue(cityVM.CityShopSubtext == valuetoTest);
        }

        [TestMethod]
        public void CityEventWebsitesetinViewmodel()
        {
            string valuetoTest = "testURL";
            Assert.IsTrue(cityVM.CityShopWebSite == valuetoTest);
        }


        [TestMethod]
        public void CityShoppingTelephonesetinViewmodel()
        {
            string valuetoTest = "123456789";
            Assert.IsTrue(cityVM.CityShopTelephone == valuetoTest);
        }

    

        [TestMethod]
        public void CityShoppingImageSourcesetinViewmodel()
        {
            string valuetoTest = @"http://testurl/url1.jpg";

            var uri = cityVM.CityShopImageSource.GetValue(UriImageSource.UriProperty);

            Assert.IsTrue(uri.ToString() == valuetoTest);
        }


        

    }
}
