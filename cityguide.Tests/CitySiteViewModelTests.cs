
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
    public class CitySiteViewModelTests
    {
       CitySite selectedCitySite { get; set; }

      CitySiteViewModel cityVM { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            selectedCitySite = new CitySite()
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


        
            Mock<INavigation> mockNav = new Mock<INavigation>();

            cityVM = new CitySiteViewModel(mockNav.Object, true);
            cityVM.SetDetails(selectedCitySite);



        }





        [TestMethod]
       public void CityIDIsSetinViewmodel()
        {
            int valueToTest = 1;
            Assert.IsTrue(cityVM.CitySiteID == valueToTest);
        }

        [TestMethod]
        public void CityNameIsSetinViewmodel()
        {
            string valuetoTest = "test site one";
            Assert.IsTrue(cityVM.CitySiteName == valuetoTest);
        }


        [TestMethod]
        public void CityNeighbourhoodsSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.NeighbourhoodID == valuetoTest);
        }

        [TestMethod]
        public void CitySiteCategoryIDSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.CitySiteCategoryID == valuetoTest);
        }

        [TestMethod]
        public void CityEventTransportIDSetinViewmodel()
        {
            int valuetoTest = 2;
            Assert.IsTrue(cityVM.TransportID == valuetoTest);
        }


        [TestMethod]
        public void CitySiteCostSetinViewmodel()
        {
            string valuetoTest = "10 EUR";
            Assert.IsTrue(cityVM.CitySiteCost == valuetoTest);
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
            Assert.IsTrue(cityVM.CitySiteAddress == valuetoTest);
        }

        [TestMethod]
        public void CitySiteDescriptionsetinViewmodel()
        {
            string valuetoTest = "Test Description";
            Assert.IsTrue(cityVM.CitySiteDescription == valuetoTest);
        }

       

        [TestMethod]
        public void CitySiteMapCoordssetinViewmodel()
        {
            string valuetoTest = "100,100";
            Assert.IsTrue(cityVM.CitySiteMapCoordinates == valuetoTest);
        }

        [TestMethod]
        public void CitySiteSubTextsetinViewmodel()
        {
            string valuetoTest = "test subtext";
            Assert.IsTrue(cityVM.CitySiteSubtext == valuetoTest);
        }

        [TestMethod]
        public void CityEventWebsitesetinViewmodel()
        {
            string valuetoTest = "testURL";
            Assert.IsTrue(cityVM.CitySiteWebSite == valuetoTest);
        }


        [TestMethod]
        public void CitySiteTelephonesetinViewmodel()
        {
            string valuetoTest = "123456789";
            Assert.IsTrue(cityVM.CitySiteTelephone == valuetoTest);
        }

    

        [TestMethod]
        public void CitySiteImageSourcesetinViewmodel()
        {
            string valuetoTest = @"http://testurl/url1.jpg";

            var uri = cityVM.CitySiteImageSource.GetValue(UriImageSource.UriProperty);

            Assert.IsTrue(uri.ToString() == valuetoTest);
        }


        

    }
}
