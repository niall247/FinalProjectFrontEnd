using System;
using System.IO;
using cityguide.Domain;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace cityguide.Data
{
    public class CityDBContext : DbContext
    {

        public CityDBContext()
        { }
        public CityDBContext(DbContextOptions<CityDBContext> options)
        : base(options)
        { }


        /// <summary>
        /// Manipulate the posts table
        /// </summary>
        /// <value>The property that allows to access the Posts table</value>
        ///  
        public DbSet<Budget> Budgets { get; set; }
       
        public DbSet<CityEvent> CityEvents { get; set; }
        public DbSet<CityMuseum> CityMuseums { get; set; }
        public DbSet<CityMuseumCategory> CityMuseumCategories { get; set; }
        public DbSet<CitySite> CitySites { get; set; }
        public DbSet<CityRestaurant> CityRestaurants { get; set; }
        public DbSet<CityShopping> CityShops { get; set; }
        public DbSet<CityShoppingCategory> CityShoppingCategories { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
       
       
        public DbSet<CityTransportOption> CityTransportOptions { get; set; }

        private const string databaseName = "madrid.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

              String databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
           //         SQLitePCL.Batteries_V2.Init();
                    databasePath = cityguide.App.dbPathToSave;
                    //databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                default:
                    databasePath = cityguide.App.dbPathToSave;
                    break;
                   // throw new NotImplementedException("Platform not supported");
            }
            // Specify that we will use sqlite and the path of the database here

           // if(optionsBuilder.DatabaseName != "")
            optionsBuilder.UseSqlite($"Filename={databasePath}");
    
                }
            }
}
}
