using HotelApiProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("AddStaff")]
        public IActionResult AddStaff()
        {

            return View();
        }
        [HttpPost]
        [Route("AddStaff")]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/staff/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                model.ImageUrl = $"/images/staff/{imageName}";
            }
            else if (model.ImageUrl == null)
            {
                model.ImageUrl = $"/images/users/no-image-users.png";
            }

            model.InstagramUrl = $"https://instagram.com/{model.InstagramUrl}";
            model.TwitterUrl = $"https://x.com/{model.TwitterUrl}";
            model.FacebookUrl = $"https://facebook.com/{model.FacebookUrl}";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateStaff/{id:int}")]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(value);
            }
            
            return View();
        }
        [HttpPost]
        [Route("UpdateStaff")]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model, IFormFile Image)
        {

            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/staff/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                model.ImageUrl = $"/images/staff/{imageName}";
            }

            else if (model.ImageUrl == null)
            {
                model.ImageUrl = $"/images/users/no-image-users.png";
            }

            model.InstagramUrl = $"https://instagram.com/{model.InstagramUrl}";
            model.TwitterUrl = $"https://x.com/{model.TwitterUrl}";
            model.FacebookUrl = $"https://facebook.com/{model.FacebookUrl}";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PutAsync("http://localhost:5173/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteStaff/{id:int}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5173/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}


