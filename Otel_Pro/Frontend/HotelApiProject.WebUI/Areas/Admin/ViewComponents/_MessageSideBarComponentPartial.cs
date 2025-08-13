using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HotelApiProject.WebUI.Areas.Admin.ViewComponents
{
    public class _MessageSideBarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı

        public _MessageSideBarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Contact/GetContactCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var responseMessage2 = await client.GetAsync("http://localhost:5173/api/SendMessage/GetSendBoxCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.inboxCount = jsonData;
            ViewBag.sentboxCount = jsonData2;
            return View();
        }
    }
}
