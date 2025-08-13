using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?dest_id=-1456928&order_by=popularity&checkout_date=2025-01-10&children_number=2&filter_by_currency=EUR&locale=tr&dest_type=city&checkin_date=2024-12-18&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&include_adjacency=true&page_number=0&adults_number=2&room_number=1&units=metric"),
                Headers =
    {
        { "x-rapidapi-key", "87ebda1640msh1f0710fdc6ebb78p11788djsnc07507e0fe79" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiBookingViewModel>(body);
                return View(values.results.ToList());
            }

        }
        [HttpPost]
        public async Task<IActionResult> Index(string cityName, string checkinDate, string checkoutDate, int adults_number,int room_number, int children_number, string children_ages)
            {
            if (!string.IsNullOrEmpty(cityName))
            {
                if (children_number != null && children_number > 0)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
                        Headers =
    {
        { "x-rapidapi-key", "87ebda1640msh1f0710fdc6ebb78p11788djsnc07507e0fe79" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                    };
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<List<ApiSearchLocationIdBookingViewModel>>(body);
                    var dest_id = model.Select(x => x.dest_id).FirstOrDefault();

                    var client2 = new HttpClient();
                    var request2 = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?dest_id={dest_id}&order_by=popularity&checkout_date={checkoutDate}&children_number={children_number}&filter_by_currency=EUR&locale=tr&dest_type=city&checkin_date={checkinDate}&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages={children_ages}&include_adjacency=true&page_number=0&adults_number={adults_number}&room_number={room_number}&units=metric"),
                        Headers =
    {
        { "x-rapidapi-key", "87ebda1640msh1f0710fdc6ebb78p11788djsnc07507e0fe79" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                    };


                    var response2 = await client2.SendAsync(request2);
                    response2.EnsureSuccessStatusCode();
                    var body2 = await response2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<ApiBookingViewModel>(body2);
                    return View(values2.results.ToList());
                }
                else
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
                        Headers =
    {
        { "x-rapidapi-key", "87ebda1640msh1f0710fdc6ebb78p11788djsnc07507e0fe79" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                    };
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<List<ApiSearchLocationIdBookingViewModel>>(body);
                    var dest_id = model.Select(x => x.dest_id).FirstOrDefault();

                    var client2 = new HttpClient();
                    var request2 = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?dest_id={dest_id}&order_by=popularity&checkout_date={checkoutDate}&filter_by_currency=EUR&locale=tr&dest_type=city&checkin_date={checkinDate}&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&include_adjacency=true&page_number=0&adults_number={adults_number}&room_number=1&units=metric"),
                        Headers =
    {
        { "x-rapidapi-key", "87ebda1640msh1f0710fdc6ebb78p11788djsnc07507e0fe79" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                    };


                    var response2 = await client2.SendAsync(request2);
                    response2.EnsureSuccessStatusCode();
                    var body2 = await response2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<ApiBookingViewModel>(body2);
                    return View(values2.results.ToList());
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
