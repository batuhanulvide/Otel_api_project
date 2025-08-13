using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.CommentDtos;
using HotelApiProject.WebUI.Dtos.RoomDtos;
using HotelApiProject.WebUI.Dtos.StaffDtos;
using HotelApiProject.WebUI.Dtos.SubscribeDtos;
using HotelApiProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelApiProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public DefaultController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult error404()
        {
            return View();
        }
        public async Task<IActionResult> Staff()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> Room()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RoomListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }
        public async Task<IActionResult> RoomDetail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(SubscribeAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", dto);
            }
            var client = _httpClientFactory.CreateClient();
            var map = _mapper.Map<Subscribe>(dto);
            var jsonData = JsonConvert.SerializeObject(map);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Subscribe", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index", dto);
        }
        [HttpPost]
        public async Task<IActionResult> MakeComment(CommentAddDto dto)
        {


            var client = _httpClientFactory.CreateClient();
            var map = _mapper.Map<Comment>(dto);
            var jsonData = JsonConvert.SerializeObject(map);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Comment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("RoomDetail", "Default", new { id = dto.RoomId });
            }
            else { return RedirectToAction("Index"); }

        }
    }
}
