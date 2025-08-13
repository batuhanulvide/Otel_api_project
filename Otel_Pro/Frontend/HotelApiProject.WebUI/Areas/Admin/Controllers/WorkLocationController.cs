using HotelApiProject.WebUI.Dtos.WorkLocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class WorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı

        public WorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/WorkLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<WorkLocationListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("AddWorkLocation")]
        public IActionResult AddWorkLocation()
        {

            return View();
        }
        [HttpPost]
        [Route("AddWorkLocation")]
        public async Task<IActionResult> AddWorkLocation(WorkLocationAddDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PostAsync("http://localhost:5173/api/WorkLocation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateWorkLocation/{id:int}")]
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/WorkLocation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<WorkLocationUpdateDto>(jsonData);
                return View(value);
            }

            return View();
        }
        [HttpPost]
        [Route("UpdateWorkLocation/{id:int}")]
        public async Task<IActionResult> UpdateWorkLocation(WorkLocationUpdateDto model, IFormFile Image)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PutAsync("http://localhost:5173/api/WorkLocation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteWorkLocation/{id:int}")]
        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5173/api/WorkLocation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
