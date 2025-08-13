using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public ReservationController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ReservationAddDto dto)
        {
            dto.ReservationDate = DateTime.Now;
            dto.Description = "Açıklama girilecek.";
            dto.ReservationStatusId = 3;
            var client = _httpClientFactory.CreateClient();
            var map = _mapper.Map<Reservation>(dto);
            var jsonData = JsonConvert.SerializeObject(map);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5173/api/Reservation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
