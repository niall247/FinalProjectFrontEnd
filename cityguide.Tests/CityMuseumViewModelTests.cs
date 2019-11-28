
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
    public class CityMuseumViewModelTests
    {
       CityMuseum selectedCityMuseum { get; set; }

      CityMuseumViewModel cityVM { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            selectedCityMuseum = new CityMuseum()
            {
             
                CityMuseumID = 1,
                CityMuseumAddress = "Test Address 1",
                CityMuseumCategoryID = 1,
                CityMuseumCost = "10 EUR",
                CityMuseumDescription = "Test Description",
                CityMuseumFavourite = true,
                CityMuseumImageURL = "http://testurl/url1.jpg",
                CityMuseumMapCoordinates = "100,100",
                CityMuseumName = "test museum one",
                ChildDetail = "test child detail",
                CityMuseumSubtext = "test subtext",
                CityMuseumTelephone = "123456789",
                CityMuseumWebSite = "testURL",
                DisabilityDetail = "disability detail test",
                TransportID = 2,
                NeighbourhoodID = 1

            };


        
            Mock<INavigation> mockNav = new Mock<INavigation>();

            cityVM = new CityMuseumViewModel(mockNav.Object, true);
            cityVM.SetDetails(selectedCityMuseum);



        }





        [TestMethod]
       public void CityIDIsSetinViewmodel()
        {
            int valueToTest = 1;
            Assert.IsTrue(cityVM.CityMuseumID == valueToTest);
        }

        [TestMethod]
        public void CityNameIsSetinViewmodel()
        {
            string valuetoTest = "test museum one";
            Assert.IsTrue(cityVM.CityMuseumName == valuetoTest);
        }


        [TestMethod]
        public void CityNeighbourhoodsSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.NeighbourhoodID == valuetoTest);
        }

        [TestMethod]
        public void CityMuseumCategoryIDSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.CityMuseumCategoryID == valuetoTest);
        }

        [TestMethod]
        public void CityEventTransportIDSetinViewmodel()
        {
            int valuetoTest = 2;
            Assert.IsTrue(cityVM.TransportID == valuetoTest);
        }


        [TestMethod]
        public void CityMuseumCostSetinViewmodel()
        {
            string valuetoTest = "10 EUR";
            Assert.IsTrue(cityVM.CityMuseumCost == valuetoTest);
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
            Assert.IsTrue(cityVM.CityMuseumAddress == valuetoTest);
        }

        [TestMethod]
        public void CityMuseumDescriptionsetinViewmodel()
        {
            string valuetoTest = "Test Description";
            Assert.IsTrue(cityVM.CityMuseumDescription == valuetoTest);
        }

       

        [TestMethod]
        public void CityMuseumMapCoordssetinViewmodel()
        {
            string valuetoTest = "100,100";
            Assert.IsTrue(cityVM.CityMuseumMapCoordinates == valuetoTest);
        }

        [TestMethod]
        public void CityMuseumSubTextsetinViewmodel()
        {
            string valuetoTest = "test subtext";
            Assert.IsTrue(cityVM.CityMuseumSubtext == valuetoTest);
        }

        [TestMethod]
        public void CityEventWebsitesetinViewmodel()
        {
            string valuetoTest = "testURL";
            Assert.IsTrue(cityVM.CityMuseumWebSite == valuetoTest);
        }


        [TestMethod]
        public void CityMuseumTelephonesetinViewmodel()
        {
            string valuetoTest = "123456789";
            Assert.IsTrue(cityVM.CityMuseumTelephone == valuetoTest);
        }

    

        [TestMethod]
        public void CityMuseumImageSourcesetinViewmodel()
        {
            string valuetoTest = @"http://testurl/url1.jpg";

            var uri = cityVM.CityMuseumImageSource.GetValue(UriImageSource.UriProperty);

            Assert.IsTrue(uri.ToString() == valuetoTest);
        }


        

    }
}
