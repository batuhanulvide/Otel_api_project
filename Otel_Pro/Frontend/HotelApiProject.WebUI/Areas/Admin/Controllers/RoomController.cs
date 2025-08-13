using HotelApiProject.WebUI.Dtos.RoomDtos;
using HotelApiProject.WebUI.Models.Room;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
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
        [HttpGet]
        [Route("AddRoom")]
        public IActionResult AddRoom()
        {

            return View();
        }
        [HttpPost]
        [Route("AddRoom")]
        public async Task<IActionResult> AddRoom(RoomAddDto model, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/Room/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                model.CoverImageUrl = $"/images/Room/{imageName}";
            }
            else if (model.CoverImageUrl == null)
            {
                model.CoverImageUrl = $"/images/users/no-image-users.png";
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateRoom/{id:int}")]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<RoomUpdateDto>(jsonData);
                return View(value);
            }

            return View();
        }
        [HttpPost]
        [Route("UpdateRoom/{id:int}")]
        public async Task<IActionResult> UpdateRoom(RoomUpdateDto model, IFormFile Image)
        {

            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/Room/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                model.CoverImageUrl = $"/images/Room/{imageName}";
            }

            else if (model.CoverImageUrl == null)
            {
                model.CoverImageUrl = $"/images/users/no-image-users.png";
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PutAsync("http://localhost:5173/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteRoom/{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5173/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
