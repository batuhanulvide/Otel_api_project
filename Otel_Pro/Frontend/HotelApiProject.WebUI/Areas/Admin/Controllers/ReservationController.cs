using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.ReservationDtos;
using HotelApiProject.WebUI.Dtos.ReservationStatusDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API Consume için gerekli istemci sınıfı
        private readonly IMapper _mapper;
        public ReservationController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Reservation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
                var map = _mapper.Map<List<ReservationListDto>>(values);
                return View(map);
            }
            return View();
        }
        [HttpGet]
        [Route("AddReservation")]
        public async Task<IActionResult> AddReservation()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/ReservationStatus");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ReservationStatusListDto>>(jsonData);
            var map = _mapper.Map<List<ReservationStatusListDto>>(values);

            List<SelectListItem> rezStatus = (from x in map
                                              select new SelectListItem
                                              {
                                                  Text = x.StatusName,
                                                  Value = x.ReservationStatusId.ToString()
                                              }).ToList();
            ViewBag.statusList = rezStatus;
            return View();
        }
        [HttpPost]
        [Route("AddReservation")]
        public async Task<IActionResult> AddReservation(ReservationAddDto model)
        {

            model.ReservationDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Reservation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateReservation/{id:int}")]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Reservation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ReservationUpdateDto>(jsonData);

                var responseMessage2 = await client.GetAsync("http://localhost:5173/api/ReservationStatus");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ReservationStatusListDto>>(jsonData2);
                var map2 = _mapper.Map<List<ReservationStatusListDto>>(values2);

                List<SelectListItem> rezStatus = (from x in map2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.StatusName,
                                                      Value = x.ReservationStatusId.ToString()
                                                  }).ToList();
                ViewBag.statusList = rezStatus;

                return View(value);
            }

            return View();
        }
        [HttpPost]
        [Route("UpdateReservation/{id:int}")]
        public async Task<IActionResult> UpdateReservation(ReservationUpdateDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriği dönüştürmek için kullanıyoruz.
            var responseMessage = await client.PutAsync("http://localhost:5173/api/Reservation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteReservation/{id:int}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5173/api/Reservation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
