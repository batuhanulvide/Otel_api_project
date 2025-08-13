using HotelApiProject.WebUI.Dtos.MessageCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelApiProject.WebUI.Areas.Admin.ViewComponents
{
    public class _MessageSideBarCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı

        public _MessageSideBarCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/MessageCategory");
            var jsonData =  await responseMessage.Content.ReadAsStringAsync();
            var value= JsonConvert.DeserializeObject<List<MessageCategoryListDto>>(jsonData);
            return View(value);
        }
    }
}
