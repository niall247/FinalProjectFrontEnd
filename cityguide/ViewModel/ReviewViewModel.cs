using System;
using Xamarin.Forms;
using cityguide.Repositories;
using cityguide.Domain;
using System.Windows.Input;
using System.Threading.Tasks;

namespace cityguide.ViewModel
{
    public class ReviewViewModel
    {

        public INavigation Navigation;

        CityReview item { get; set; }

        public ReviewViewModel(CityReview review, INavigation navigation)
        {

            item = review;
            Navigation = navigation;

        }

        public ICommand postReviewCommand => new Command(async () => await postReview());

        public string ReviewRatingSelection { get; set; }
        public string ReviewContents { get; set; }

        public async Task postReview()

        {
          


            CityReviewRepository repository = new CityReviewRepository();

            item.reviewRating = ReviewRatingSelection;
            item.reviewText = ReviewContents;
            

            repository.PostReview(item);

            // DisplayAlert("Alert", "You have been alerted", "OK");


            await Navigation.PopAsync();

        }
    }
}
