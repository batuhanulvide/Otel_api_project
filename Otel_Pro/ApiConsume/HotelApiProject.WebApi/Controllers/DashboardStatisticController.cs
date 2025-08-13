using HotelApiProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardStatisticController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IReservationService _ReservationService;
        private readonly IGuestService _GuestService;
        private readonly IRoomService _RoomService;

        public DashboardStatisticController(IStaffService staffService, IReservationService reservationService, IGuestService guestService, IRoomService roomService)
        {
            _staffService = staffService;
            _ReservationService = reservationService;
            _GuestService = guestService;
            _RoomService = roomService;
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            int count = _staffService.TStaffCount();
            return Ok(count);
        }
        [HttpGet("ReservationCount")]
        public IActionResult ReservationCount()
        {
            var value = _ReservationService.TGetReservationCount();
            return Ok(value);
        }
        [HttpGet("GuestCount")]
        public IActionResult GuestCount()
        {
            var value = _GuestService.TGetGuestCount();
            return Ok(value);
        }
        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var value = _RoomService.TGetRoomCount();
            return Ok(value);
        }
    }
}
