using HotelApiProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelApiProject.WebUI.Areas.Admin.ViewComponents
{
    public class _DashboardTeamComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardTeamComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Staff/GetStaffLast4");
            var jsonData= await responseMessage.Content.ReadAsStringAsync();
            var value= JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
            return View(value);
        }
    }
}
