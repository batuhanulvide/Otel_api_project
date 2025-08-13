using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Areas.Admin.Models.Dashboard;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelApiProject.WebUI.Areas.Admin.ViewComponents
{
    public class _DashboardStatisticCardComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticCardComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            //--StaffCount   
            var responseMessage = await client.GetAsync("http://localhost:5173/api/DashboardStatistic/StaffCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<int>(jsonData);
            //--ReservationCount
            var responseMessage2 = await client.GetAsync("http://localhost:5173/api/DashboardStatistic/ReservationCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<int>(jsonData2);
            //---
            var responseMessage3 = await client.GetAsync("http://localhost:5173/api/DashboardStatistic/GuestCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var value3 = JsonConvert.DeserializeObject<int>(jsonData3);
            //--
            var responseMessage4 = await client.GetAsync("http://localhost:5173/api/DashboardStatistic/RoomCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            var value4 = JsonConvert.DeserializeObject<int>(jsonData4);
            //--Data
            ViewBag.staffCount = value;
            ViewBag.reservationCount = value2;
            ViewBag.guestCount = value3;
            ViewBag.roomCount = value4;
            return View();
        }
    }
}
