using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.CommentDtos;
using HotelApiProject.WebUI.Dtos.RoomDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CommentController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _mapper = mapper;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Comment");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Comment>>(jsonData);
                var map =_mapper.Map<List<CommentListDto>>(values);
                return View(map);
            }
            return View();
        }
        [HttpGet]
        [Route("AddComment")]
        public IActionResult AddComment()
        {

            return View();
        }
        [HttpPost]
        [Route("AddComment")]
        public async Task<IActionResult> AddComment(CommentAddDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Comment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateComment/{id:int}")]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Comment/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CommentUpdateDto>(jsonData);

                //** Oda Listesi
                var responseMessageRoom = await client.GetAsync("http://localhost:5173/api/Room/");
                var jsonDataRoom = await responseMessageRoom.Content.ReadAsStringAsync();
                var valueRoom = JsonConvert.DeserializeObject<List<Room>>(jsonDataRoom);
                var mapRoom = _mapper.Map<List<RoomListDto>>(valueRoom);

                List<SelectListItem> roomList = (from x in mapRoom
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Title,
                                                     Value = x.RoomId.ToString(),
                                                 }).ToList();
                ViewBag.roomList = roomList;

                //** Kullanıcı listesi
                var users = _userManager.Users.ToList();
                List<SelectListItem> userList = (from x in users
                                                 select new SelectListItem
                                                 {
                                                     Text = $"{x.Name} {x.Surname}",
                                                     Value = x.Id.ToString(),
                                                 }).ToList();
                ViewBag.userList = userList;
                return View(value);
            }

            return View();
        }
        [HttpPost]
        [Route("UpdateComment/{id:int}")]
        public async Task<IActionResult> UpdateComment(CommentUpdateDto model)
        {
            var map = _mapper.Map<Comment>(model);
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(map);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PutAsync("http://localhost:5173/api/Comment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteComment/{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5173/api/Comment/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
