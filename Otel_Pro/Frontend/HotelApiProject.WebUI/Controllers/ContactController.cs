using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelApiProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public ContactController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/MessageCategory");
            var jsonData= await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<MessageCategory>>(jsonData);
            List<SelectListItem> messageCategory = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text=x.MessageCategoryName,
                                                        Value=x.MessageCategoryId.ToString()
                                                    }).ToList();
            ViewBag.contactCategory=messageCategory;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactAddDto dto)
        {
            var client = _httpClientFactory.CreateClient();
        
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {               
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
