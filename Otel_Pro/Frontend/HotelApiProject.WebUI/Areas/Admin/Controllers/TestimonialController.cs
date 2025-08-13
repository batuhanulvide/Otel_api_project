using HotelApiProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("AddTestimonial")]
        public IActionResult AddTestimonial()
        {

            return View();
        }
        [HttpPost]
        [Route("AddTestimonial")]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel model, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/Testimonial/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                model.ImageUrl = $"/images/Testimonial/{imageName}";
            }
            else if (model.ImageUrl == null)
            {
                model.ImageUrl = $"/images/users/no-image-users.png";
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateTestimonial/{id:int}")]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonData);
                return View(value);
            }

            return View();
        }
        [HttpPost]
        [Route("UpdateTestimonial")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel model, IFormFile Image)
        {

            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/Testimonial/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                model.ImageUrl = $"/images/Testimonial/{imageName}";
            }

            else if (model.ImageUrl == null)
            {
                model.ImageUrl = $"/images/users/no-image-users.png";
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PutAsync("http://localhost:5173/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteTestimonial/{id:int}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5173/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
