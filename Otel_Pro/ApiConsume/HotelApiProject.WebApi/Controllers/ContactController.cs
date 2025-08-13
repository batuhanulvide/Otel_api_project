using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]
        public IActionResult ListContact()
        {
            var value = _ContactService.TGetList();
            return Ok(value);
        }
        [HttpGet("GetMessageByCategory/{id}")]
        public IActionResult GetMessageByCategory(int id)
        {
            var value = _ContactService.TGetMessageByCategory(id);
            return Ok(value);
        }
        [HttpGet("GetNewMessageForNavbar")]
        public IActionResult GetNewMessageForNavbar()
        {
            var value = _ContactService.TGetNewMessageForNavbar();
            return Ok(value);
        }
        [HttpGet("GetListContact")]
        public IActionResult GetListContact()
        {
            var value = _ContactService.TGetListContact();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _ContactService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddContact(Contact Contact)
        {
            _ContactService.TInsert(Contact);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _ContactService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateContact(Contact Contact)
        {
            _ContactService.TUpdate(Contact);
            return Ok();
        }
        [HttpGet("[action]")]
        public IActionResult GetContactCount()
        {
            int count = _ContactService.TGetContactCount();
            return Ok(count);
        }
    }
}

