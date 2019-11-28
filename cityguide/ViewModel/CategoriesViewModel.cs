using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using cityguide.View;

namespace cityguide.ViewModels
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        public INavigation Navigation { get; set; }

         public ICommand GetRestaurantsCommand => new Command(async () => await LoadCityRestaurantsViewModel());

        public ICommand GetCityEventsCommand => new Command(async () => await LoadCityEventsViewModel());

        public ICommand GetCitySitesCommand => new Command(async () => await LoadCitySitesViewModel());

        public ICommand GetCityShopsCommand => new Command(async () => await LoadCityShopsViewModel());

        public ICommand GetCityMuseumsCommand => new Command(async () => await LoadCityMuseumsViewModel());

        public ICommand GetCityTransportOptionsCommand => new Command(async () => await LoadCityTransportOptionsViewModel());

        /*
        public async Task LoadRestaurantsViewModel()

        {
        */
        // await Navigation.PushAsync(new EventsListView());

        public async Task LoadCityEventsViewModel()

        {
            await Navigation.PushAsync(new CityEventsListView());
        }

        public async Task LoadCityRestaurantsViewModel()

        {
            await Navigation.PushAsync(new CityRestaurantsListView());
        }

        public async Task LoadCitySitesViewModel()

        {
            await Navigation.PushAsync(new CitySitesListView());
        }
        public async Task LoadCityShopsViewModel()

        {
            await Navigation.PushAsync(new CityShopListView());
        }

        public async Task LoadCityMuseumsViewModel()

        {
            await Navigation.PushAsync(new CityMuseumsListView());
        }

        public async Task LoadCityTransportOptionsViewModel()

        {
            await Navigation.PushAsync(new CityTransportOptionsListview());
        }

    }
}