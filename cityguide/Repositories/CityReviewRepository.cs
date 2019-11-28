using System;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace cityguide.Repositories
{
    public class CityReviewRepository
    {

        public CityReviewRepository()
        {

           
        }

        public async void PostReview(CityReview review)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"http://35.195.148.99/api/reviews");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                string abc = JsonConvert.SerializeObject(review);
                StringContent c = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress, c);




            }
        }



        public async Task<List<CityReview>> GetReviews(int itemId, string Category)
        {
            // To be implemented ....filter! 

            List<CityReview> reviews = new List<CityReview>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"http://35.195.148.99/api/reviews");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    var a = await response.Content.ReadAsStringAsync();

                    reviews = JsonConvert.DeserializeObject<List<CityReview>>(a);

                    reviews = reviews.Where(b => b.reviewItemID == itemId && b.ReviewCategory == Category).ToList();
                }


            }



           




            return reviews;


                
        }

    }
}
