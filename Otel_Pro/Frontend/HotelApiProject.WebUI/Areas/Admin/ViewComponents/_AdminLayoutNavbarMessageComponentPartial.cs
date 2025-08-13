using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.ContactDtos;
using HotelApiProject.WebUI.Dtos.SendMessageDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelApiProject.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutNavbarMessageComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public _AdminLayoutNavbarMessageComponentPartial(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Contact/GetNewMessageForNavbar");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
                var map = _mapper.Map<List<ContactListDto>>(values);
                return View(map);
            }
            return View();
        }
    }
}
