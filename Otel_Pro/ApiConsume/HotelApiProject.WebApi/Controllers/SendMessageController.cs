using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _SendMessageService;

        public SendMessageController(ISendMessageService SendMessageService)
        {
            _SendMessageService = SendMessageService;
        }

        [HttpGet]
        public IActionResult ListSendMessage()
        {
            var value = _SendMessageService.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var value = _SendMessageService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage SendMessage)
        {
            _SendMessageService.TInsert(SendMessage);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            _SendMessageService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage SendMessage)
        {
            _SendMessageService.TUpdate(SendMessage);
            return Ok();
        }

        [HttpGet("GetSendBoxCount")]
        public IActionResult GetSendBoxCount()
        {

            return Ok(_SendMessageService.TGetSendboxCount());
        }
    }
}
