using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HotelApiProject.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutNavbarProfileComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminLayoutNavbarProfileComponentPartial(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.Name == null)
            {
                return View();
            }
            else
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userPhoto = user.ImageUrl;
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:5173/api/Contact/GetContactCount");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.inboxCount = jsonData;
                return View();
            }
        }
    }
}
