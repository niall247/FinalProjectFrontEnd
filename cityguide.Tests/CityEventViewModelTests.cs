
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
    public class CityEventViewModelTests
    {
       CityEvent selectedCityEvent { get; set; }

      CityEventViewModel cityVM { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            selectedCityEvent = new CityEvent()
            {
                CityEventID = 1,
                CityEventName = "CityEventTestName",
                CityEventStartDate = 19318
                       ,
                CityEventEndDate = 19332
                       ,
                CityEventCost = "5 EUR"
                ,
                NeighbourhoodID = 1,
                ChildDetail = "CheckChildDetail",

                CityEventAddress = "CheckAddressForEvent",
                CityEventCategoryID = 1,
                CityEventDescription = "CheckEventDescription"
                ,
                CityEventImageURL = @"http://wwww.cloudtest.com/test.jpg"
                ,
                TransportID = 1
                ,
                CityEventMapCoordinates = "40.369102, -3.684451"

                ,
                DisabilityDetail = "CheckDetailForDisability"
                ,
                CityEventWebSite = "WebSiteURL"
                ,
                CityEventTelephone = "12345"
                ,
                CityEventSubtext = "CheckSubtextForEvent"



            };

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityEventsListViewModel mylv = new CityEventsListViewModel(mockNav.Object);

            cityVM = new CityEventViewModel(mockNav.Object, true);
            cityVM.SetDetails(selectedCityEvent);



        }





        [TestMethod]
       public void CityIDIsSetinViewmodel()
        {
            int valueToTest = 1;
            Assert.IsTrue(cityVM.CityEventID == valueToTest);
        }

        [TestMethod]
        public void CityNameIsSetinViewmodel()
        {
            string valuetoTest = "CityEventTestName";
            Assert.IsTrue(cityVM.CityEventName == valuetoTest);
        }

        [TestMethod]
        public void CityEventStartDateIsSetinViewmodel()
        {
            int valuetoTest = 19318;
            Assert.IsTrue(cityVM.CityEventStartDate == valuetoTest);
        }

        [TestMethod]
        public void CityEventEndDateIsSetinViewmodel()
        {
            int valuetoTest = 19332;
            Assert.IsTrue(cityVM.CityEventEndDate == valuetoTest);
        }

        [TestMethod]
        public void CityEventNeighbourhoodsSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.NeighbourhoodID == valuetoTest);
        }

        [TestMethod]
        public void CityEventCategoryIDSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.CityEventCategoryID == valuetoTest);
        }

        [TestMethod]
        public void CityEventTransportIDSetinViewmodel()
        {
            int valuetoTest = 1;
            Assert.IsTrue(cityVM.TransportID == valuetoTest);
        }


        [TestMethod]
        public void CityEventCostSetinViewmodel()
        {
            string valuetoTest = "5 EUR";
            Assert.IsTrue(cityVM.CityEventCost == valuetoTest);
        }

        [TestMethod]
        public void CityEventChildDetailSetinViewmodel()
        {
            string valuetoTest = "CheckChildDetail";
            Assert.IsTrue(cityVM.ChildDetail == valuetoTest);
        }

        [TestMethod]
        public void CityEventDisabilityDetailSetinViewmodel()
        {
            string valuetoTest = "CheckDetailForDisability";
            Assert.IsTrue(cityVM.DisabilityDetail == valuetoTest);
        }

        [TestMethod]
        public void CityEventAddresssetinViewmodel()
        {
            string valuetoTest = "CheckAddressForEvent";
            Assert.IsTrue(cityVM.CityEventAddress == valuetoTest);
        }

        [TestMethod]
        public void CityEventDescriptionsetinViewmodel()
        {
            string valuetoTest = "CheckEventDescription";
            Assert.IsTrue(cityVM.CityEventDescription == valuetoTest);
        }

       

        [TestMethod]
        public void CityEventMapCoordssetinViewmodel()
        {
            string valuetoTest = "40.369102, -3.684451";
            Assert.IsTrue(cityVM.CityEventMapCoordinates == valuetoTest);
        }

        [TestMethod]
        public void CityEventSubTextsetinViewmodel()
        {
            string valuetoTest = "CheckSubtextForEvent";
            Assert.IsTrue(cityVM.CityEventSubtext == valuetoTest);
        }

        [TestMethod]
        public void CityEventWebsitesetinViewmodel()
        {
            string valuetoTest = "WebSiteURL";
            Assert.IsTrue(cityVM.CityEventWebSite == valuetoTest);
        }


        [TestMethod]
        public void CityEventTelephonesetinViewmodel()
        {
            string valuetoTest = "12345";
            Assert.IsTrue(cityVM.CityEventTelephone == valuetoTest);
        }

        [TestMethod]
        public void CityEventTimingsinViewmodel()
        {

           

            string valuetoTest = "14-Nov-2019\n To 28-Nov-2019";
            Assert.IsTrue(cityVM.EventTimings == valuetoTest);
        }

        [TestMethod]
        public void CityEventImageSourcesetinViewmodel()
        {
            string valuetoTest = @"http://wwww.cloudtest.com/test.jpg";

            var uri = cityVM.CityEventImageSource.GetValue(UriImageSource.UriProperty);

            Assert.IsTrue(uri.ToString() == valuetoTest);
        }


        

    }
}
