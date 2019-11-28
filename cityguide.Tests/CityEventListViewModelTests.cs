
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
    public class CityEventListViewModelTests
    {
       List<CityEvent> allEvents { get; set; }

        [TestInitialize]
        public void Setup()

        {
            MockForms.Init();
            allEvents = new List<CityEvent>();
            addEvents();

        }

        

        public void addEvents()
        {
            
            allEvents.Add(new CityEvent
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
                CityEventImageURL = "CheckURl.Cloud"
                ,
                TransportID = 1
                ,
                CityEventMapCoordinates = "40.369102, -3.684451"
             
                , DisabilityDetail = "CheckDetailForDisability"
                , CityEventWebSite = "WebSiteURL"
                , CityEventTelephone ="12345"
                , CityEventSubtext = "CheckSubtextForEvent"
                , CityEventFavourite = true
                
            });

            allEvents.Add(new CityEvent
            {
                CityEventID = 2,
                CityEventName = "CityEventTestNameTwo",
                CityEventStartDate = 19318
                       ,
                CityEventEndDate = 19335
                       ,
                CityEventCost = "5 EUR"
                ,
                NeighbourhoodID = 1,
                ChildDetail = "CheckChildDetail2",
                ChildFriendly = true,
                CityEventAddress = "CheckAddressForEvent2",
                CityEventCategoryID = 1,
                CityEventDescription = "CheckEventDescription2"
                ,
                CityEventImageURL = "CheckURl.Cloud"
                ,
                TransportID = 1
                ,
                CityEventMapCoordinates = "40.369102, -3.684451"
                ,
            

                
                DisabilityDetail = "CheckDetailForDisability2"
                ,
                CityEventWebSite = "WebSiteURL"
                ,
                CityEventTelephone = "12345"
                ,
                CityEventSubtext = "CheckSubtextForEvent2"
                
               

            }) ;

            allEvents.Add(new CityEvent
            {
                CityEventID = 3,
                CityEventName = "CityEventTestNameThree",
                CityEventStartDate = 19318
                  ,
                CityEventEndDate = 19335
                  ,
                CityEventCost = "5 EUR"
           ,
                NeighbourhoodID = 1,
                ChildDetail = "CheckChildDetail2",
      
                CityEventAddress = "CheckAddressForEvent2",
                CityEventCategoryID = 1,
                CityEventDescription = "CheckEventDescription2"
           ,
                CityEventImageURL = "CheckURl.Cloud"
           ,
                TransportID = 1
           ,
                CityEventMapCoordinates = "40.369102, -3.684451"
           ,
                DisabilityAccess = true
           ,
                DisabilityDetail = "CheckDetailForDisability2"
           ,
                CityEventWebSite = "WebSiteURL"
           ,
                CityEventTelephone = "12345"
           ,
                CityEventSubtext = "CheckSubtextForEvent2"
                
                

            });





        }



        [TestMethod]
       public void TestValuesSetForViewModel()
        {

            Mock<CityEventRepository> mock = new Mock<CityEventRepository>(null);
             mock.Setup(a => a.GetAllCityEvents()).Returns(allEvents);

            Mock<INavigation> mockNav = new Mock<INavigation>();
            CityEventsListViewModel mylv = new CityEventsListViewModel(mockNav.Object);
       

          var ListOfCityEvents  = mylv.setListOfEvents(mock.Object);

            Assert.IsTrue(ListOfCityEvents.Count() > 0);


        }


        [TestMethod]
        public void TestFavouriteFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<INavigation> mockNav = new Mock<INavigation>();
           // CityEventViewModel vma = new CityEventViewModel(1, mockNav.Object);


            Mock<CityEventRepository> mock = new Mock<CityEventRepository>(null);
            mock.Setup(a => a.GetAllCityEvents()).Returns(allEvents);

            
            CityEventsListViewModel mylv = new CityEventsListViewModel(mockNav.Object);

            mylv.SetCityEvents(mock.Object.GetAllCityEvents(), true);

            mylv.SetFavouriteFilter(mock.Object, true);


            int countafterset=  mylv.allCityEvents.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

        [TestMethod]
        public void TestDisabilityFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<INavigation> mockNav = new Mock<INavigation>();
            // CityEventViewModel vma = new CityEventViewModel(1, mockNav.Object);


            Mock<CityEventRepository> mock = new Mock<CityEventRepository>(null);
            mock.Setup(a => a.GetAllCityEvents()).Returns(allEvents);


            CityEventsListViewModel mylv = new CityEventsListViewModel(mockNav.Object);

            mylv.SetCityEvents(mock.Object.GetAllCityEvents(), true);

          
            mylv.SetDisabledFilter(mock.Object, true);
        

            int countafterset = mylv.allCityEvents.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }
        [TestMethod]
        public void TestChildFilterForViewModel()
        {
            // Test : Expected Number is 1
            int ExpectedResult = 1;

            Mock<INavigation> mockNav = new Mock<INavigation>();
            // CityEventViewModel vma = new CityEventViewModel(1, mockNav.Object);


            Mock<CityEventRepository> mock = new Mock<CityEventRepository>(null);
            mock.Setup(a => a.GetAllCityEvents()).Returns(allEvents);


            CityEventsListViewModel mylv = new CityEventsListViewModel(mockNav.Object);

            mylv.SetCityEvents(mock.Object.GetAllCityEvents(), true);

            mylv.SetChildFilter(mock.Object, true);
        

            int countafterset = mylv.allCityEvents.Count();

            Assert.IsTrue(countafterset == ExpectedResult);

        }

    }
}
