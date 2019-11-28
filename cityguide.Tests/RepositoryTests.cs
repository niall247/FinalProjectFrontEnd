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

namespace cityguide.Tests
{
    [TestClass]
    public class RepositoryTests
    {
      
       


        private CityDBContext _ctx { get; set; }

        public void setUpDB()
        {


            var options = new DbContextOptionsBuilder<CityDBContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            _ctx = new CityDBContext(options);
            _ctx.Budgets.Add(new Domain.Budget { BudgetID = 1, BudgetName = "TestBudget" });
            _ctx.CityEvents.Add(new Domain.CityEvent { CityEventID = 1, CityEventName = "TestEventOneDisabilityAccess", DisabilityAccess = true });
            _ctx.CityEvents.Add(new Domain.CityEvent { CityEventID = 2, CityEventName = "TestEventTwoChildFriendly", ChildFriendly = true });
            _ctx.CityMuseums.Add(new Domain.CityMuseum { CityMuseumID = 1, CityMuseumName = "TestMuseumOneDisabilityAccess", DisabilityAccess = true });
            _ctx.CityMuseums.Add(new Domain.CityMuseum { CityMuseumID = 2, CityMuseumName = "TestMuseumTwoChildFriendly", ChildFriendly = true });
            _ctx.CityRestaurants.Add(new Domain.CityRestaurant { CityRestaurantID = 1, CityRestaurantName = "TestRestaurantOneChildFriendly", ChildFriendly = true });
            _ctx.CityRestaurants.Add(new Domain.CityRestaurant { CityRestaurantID = 2, CityRestaurantName = "TestRestaurantTwoGlutenFree", GlutenFree = true });
            _ctx.CitySites.Add(new CitySite { CitySiteID = 1, CitySiteName = "SiteOneChildFriendly", ChildFriendly = true });
            _ctx.CitySites.Add(new CitySite { CitySiteID = 2, CitySiteName = "SiteTwoDisabilityAccess", DisabilityAccess = true });
            _ctx.CityShops.Add(new CityShopping { CityShoppingID = 1, CityShoppingName = "ShopOneChildFriendly", ChildFriendly = true });
            _ctx.CityShops.Add(new CityShopping { CityShoppingID = 2, CityShoppingName = "ShopTwoDisabilityAccess", DisabilityAccess = true });
            _ctx.Cuisines.Add(new Cuisine { CuisineID = 1, CuisineName = "CuisineNameTestName" });

            _ctx.SaveChanges();

        }


        [TestInitialize]

        public  void SetUpContext()
        {
            MockForms.Init();
            setUpDB();


        }


        [TestMethod]
        public void TestBudgetRepositoryReturnsValue()
        {

                BudgetRepository rep = new BudgetRepository(_ctx);
                string testBudgetName = rep.GetBudgetName(1);

                Assert.IsTrue(testBudgetName == "TestBudget");
        



        }

        [TestMethod]
        
        public void TestCityEventRepositoryReturnsCorrectCount()
        {
           
                int CorrectCount = 2;

                CityEventRepository rep = new CityEventRepository(_ctx);


                Assert.IsTrue(rep.GetAllCityEvents().Count == CorrectCount);
           


        }
        [TestMethod]
        public void TestCityEventRepositoryReturnsFilteredDisabilityList()
        {
           
            CityEventRepository rep = new CityEventRepository(_ctx);
            var item = rep.GetAllCityEventsFiltered(true,null).FirstOrDefault();

            Assert.IsTrue(item.CityEventName == "TestEventOneDisabilityAccess");



        }
        [TestMethod]
        public void TestCityEventRepositoryReturnsFilteredChildList()
        {

            CityEventRepository rep = new CityEventRepository(_ctx);
            var item = rep.GetAllCityEventsFiltered(null, true).FirstOrDefault();

            Assert.IsTrue(item.CityEventName == "TestEventTwoChildFriendly");



        }
        [TestMethod]

        public void TestCityMuseumRepositoryReturnsCorrectCount()
        {

            int CorrectCount = 2;

            CityMuseumRepository rep = new CityMuseumRepository(_ctx);


            Assert.IsTrue(rep.GetAllCityMuseums().Count == CorrectCount);



        }

        [TestMethod]
        public void TestCityMuseumRepositoryReturnsFilteredDisabilityList()
        {

            CityMuseumRepository rep = new CityMuseumRepository(_ctx);
            var item = rep.GetAllCityMuseumsFiltered(true, null).FirstOrDefault();

            Assert.IsTrue(item.CityMuseumName == "TestMuseumOneDisabilityAccess");



        }
        [TestMethod]
        public void TestCityMuseumRepositoryReturnsFilteredChildList()
        {

            CityMuseumRepository rep = new CityMuseumRepository(_ctx);
            var item = rep.GetAllCityMuseumsFiltered(null, true).FirstOrDefault();

            Assert.IsTrue(item.CityMuseumName == "TestMuseumTwoChildFriendly");



        }


        [TestMethod]

        public void TestCityRestaurantRepositoryReturnsCorrectCount()
        {

            int CorrectCount = 2;

            CityRestaurantRepository rep = new CityRestaurantRepository(_ctx);


            Assert.IsTrue(rep.GetAllCityRestaurants().Count == CorrectCount);



        }

        [TestMethod]
        public void TestCityRestaurantRepositoryReturnsFilteredChildList()
        {

            CityRestaurantRepository rep = new CityRestaurantRepository(_ctx);
            var item = rep.GetAllCityRestaurantsFiltered(null, true,null,null,null,null,null,null).FirstOrDefault();

            Assert.IsTrue(item.CityRestaurantName == "TestRestaurantOneChildFriendly");



        }

        [TestMethod]
        public void TestCityRestaurantRepositoryReturnsFilteredGlutenFreeList()
        {

            CityRestaurantRepository rep = new CityRestaurantRepository(_ctx);
            var item = rep.GetAllCityRestaurantsFiltered(null, null, null,null, true, null, null, null).FirstOrDefault();

            Assert.IsTrue(item.CityRestaurantName == "TestRestaurantTwoGlutenFree");



        }

        [TestMethod]

        public void TestCitySiteRepositoryReturnsCorrectCount()
        {

            int CorrectCount = 2;

            CitySiteRepository rep = new CitySiteRepository(_ctx);


            Assert.IsTrue(rep.GetAllCitySites().Count == CorrectCount);



        }


        [TestMethod]
        public void TestCitySiteRepositoryReturnsFilteredChildList()
        {

            CitySiteRepository rep = new CitySiteRepository(_ctx);
            var item = rep.GetAllCitySitesFiltered(null,true).FirstOrDefault();

            Assert.IsTrue(item.CitySiteName == "SiteOneChildFriendly");



        }

        [TestMethod]
        public void TestCitySiteRepositoryReturnsFilteredDisabledList()
        {


            CitySiteRepository rep = new CitySiteRepository(_ctx);
            var item = rep.GetAllCitySitesFiltered(true, null).FirstOrDefault();

            Assert.IsTrue(item.CitySiteName == "SiteTwoDisabilityAccess");



        }


        [TestMethod]

        public void TestCityShoppingRepositoryReturnsCorrectCount()
        {

            int CorrectCount = 2;

            CityShoppingRepository rep = new CityShoppingRepository(_ctx);


            Assert.IsTrue(rep.GetAllCityShops().Count == CorrectCount);



        }


        [TestMethod]
        public void TestCityShoppingRepositoryReturnsFilteredChildList()
        {

            CityShoppingRepository rep = new CityShoppingRepository(_ctx);
            var item = rep.GetAllCityShopsFiltered(null, true).FirstOrDefault();

            Assert.IsTrue(item.CityShoppingName == "ShopOneChildFriendly");



        }

        [TestMethod]
        public void TestCityShoppingRepositoryReturnsFilteredDisabledList()
        {


            CityShoppingRepository rep = new CityShoppingRepository(_ctx);
            var item = rep.GetAllCityShopsFiltered(true, null).FirstOrDefault();

            Assert.IsTrue(item.CityShoppingName == "ShopTwoDisabilityAccess");



        }


        [TestMethod]
        public void TestCuisineRepositoryReturnsCusineName()
        {

            CuisineRepository rep = new CuisineRepository(_ctx);
            string testCusineName = rep.GetCuisineName(1);

            Assert.IsTrue(testCusineName == "CuisineNameTestName");




        }




    }
}
