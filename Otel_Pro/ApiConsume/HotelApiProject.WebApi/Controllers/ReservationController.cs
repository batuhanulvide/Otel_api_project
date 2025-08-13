using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _ReservationService;

        public ReservationController(IReservationService ReservationService)
        {
            _ReservationService = ReservationService;
        }
        [HttpGet]
        public IActionResult ListReservation()
        {
            var value = _ReservationService.TGetListReservationWithStatus();
            return Ok(value);
        }
        [HttpGet("GetReservationLast6")]
        public IActionResult GetReservationLast6()
        {
            var value = _ReservationService.TGetReservationLast6();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var value = _ReservationService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddReservation(Reservation Reservation)
        {
            _ReservationService.TInsert(Reservation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            _ReservationService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateReservation(Reservation Reservation)
        {
            _ReservationService.TUpdate(Reservation);
            return Ok();
        }
    }
}
