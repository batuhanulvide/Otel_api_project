using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult ListStaff()
        {
            var value = _staffService.TGetList();
            return Ok(value);
        }
        [HttpGet("GetStaffLast4")]
        public IActionResult GetStaffLast4()
        {
            var value = _staffService.TGetStaffLast4();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var value= _staffService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            _staffService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }
    }
}
