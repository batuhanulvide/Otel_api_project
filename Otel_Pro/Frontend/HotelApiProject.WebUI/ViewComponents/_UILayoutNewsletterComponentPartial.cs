using HotelApiProject.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebUI.ViewComponents
{
    public class _UILayoutNewsletterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new SubscribeAddDto());
        }
    }
}
