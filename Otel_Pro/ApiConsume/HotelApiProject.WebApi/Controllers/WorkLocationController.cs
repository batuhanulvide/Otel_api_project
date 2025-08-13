using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _WorkLocationService;

        public WorkLocationController(IWorkLocationService WorkLocationService)
        {
            _WorkLocationService = WorkLocationService;
        }

        [HttpGet]
        public IActionResult ListWorkLocation()
        {
            var value = _WorkLocationService.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var value = _WorkLocationService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation WorkLocation)
        {
            _WorkLocationService.TInsert(WorkLocation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(int id)
        {
            _WorkLocationService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation WorkLocation)
        {
            _WorkLocationService.TUpdate(WorkLocation);
            return Ok();
        }
    }
}
