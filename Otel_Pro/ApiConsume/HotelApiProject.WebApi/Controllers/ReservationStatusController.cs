using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationStatusController : ControllerBase
    {
        private readonly IReservationStatusService _ReservationStatusService;

        public ReservationStatusController(IReservationStatusService ReservationStatusService)
        {
            _ReservationStatusService = ReservationStatusService;
        }

        [HttpGet]
        public IActionResult ListReservationStatus()
        {
            var value = _ReservationStatusService.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetReservationStatus(int id)
        {
            var value = _ReservationStatusService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddReservationStatus(ReservationStatus ReservationStatus)
        {
            _ReservationStatusService.TInsert(ReservationStatus);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReservationStatus(int id)
        {
            _ReservationStatusService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateReservationStatus(ReservationStatus ReservationStatus)
        {
            _ReservationStatusService.TUpdate(ReservationStatus);
            return Ok();
        }
    }
}
