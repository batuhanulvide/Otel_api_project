using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
