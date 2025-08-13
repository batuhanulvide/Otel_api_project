using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _AboutService;

        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        [HttpGet]
        public IActionResult ListAbout()
        {
            var value = _AboutService.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _AboutService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddAbout(About About)
        {
            _AboutService.TInsert(About);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            _AboutService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbout(About About)
        {
            _AboutService.TUpdate(About);
            return Ok();
        }
    }
}
