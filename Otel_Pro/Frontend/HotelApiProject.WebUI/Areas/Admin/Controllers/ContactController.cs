using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.ContactDtos;
using HotelApiProject.WebUI.Dtos.SendMessageDtos;
using HotelApiProject.WebUI.Models.Contact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı
        private readonly IMapper _mapper;
        public ContactController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        [Route("SentMessageList")]
        public async Task<IActionResult> SentMessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SendMessage>>(jsonData);
                var map = _mapper.Map<List<SendMessageListDto>>(values);
                return View(map);
            }
            return View();
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Contact/GetListContact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
                var map = _mapper.Map<List<ContactListDto>>(values);
                return View(map);
            }
            return View();
        }
        [Route("MessageListByCategory/{id:int}")]
        public async Task<IActionResult> MessageListByCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Contact/GetMessageByCategory/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
                var map = _mapper.Map<List<ContactListDto>>(values);
                return View(map);
            }
            return View();
        }
        [HttpGet]
        [Route("AddSendMessage")]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("AddSendMessage")]
        public async Task<IActionResult> AddSendMessage(SendMessageAddDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
                var responseMessage = await client.PostAsync("http://localhost:5173/api/SendMessage", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SentMessageList");
                }
                return View();
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        [Route("SentReadMessage/{id:int}")]
        public async Task<IActionResult> SentReadMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var vales = JsonConvert.DeserializeObject<SendMessageListDto>(jsonData);
                return View(vales);
            }
            return View();
        }
        [HttpGet]
        [Route("InboxReadMessage/{id:int}")]
        public async Task<IActionResult> InboxReadMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var vales = JsonConvert.DeserializeObject<ContactListDto>(jsonData);

                vales.IsApproved = true;
                var jsonData2 = JsonConvert.SerializeObject(vales);
                StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
                var responseMessage2 = await client.PutAsync("http://localhost:5173/api/Contact", stringContent2);
                return View(vales);
            }
            return View();
        }
        [HttpPost]
        [Route("InboxReadMessage/{id:int}")]
        public async Task<IActionResult> InboxReadMessage(SendMessageAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(dto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
                var responseMessage = await client.PostAsync("http://localhost:5173/api/SendMessage", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SentMessageList");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
