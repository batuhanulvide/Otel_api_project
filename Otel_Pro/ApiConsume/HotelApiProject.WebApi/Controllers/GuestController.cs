using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _GuestService;

        public GuestController(IGuestService GuestService)
        {
            _GuestService = GuestService;
        }

        [HttpGet]
        public IActionResult ListGuest()
        {
            var value = _GuestService.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var value = _GuestService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddGuest(Guest Guest)
        {
            _GuestService.TInsert(Guest);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGuest(int id)
        {
            _GuestService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest Guest)
        {
            _GuestService.TUpdate(Guest);
            return Ok();
        }
    }
}
