using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _MessageCategoryService;

        public MessageCategoryController(IMessageCategoryService MessageCategoryService)
        {
            _MessageCategoryService = MessageCategoryService;
        }

        [HttpGet]
        public IActionResult ListMessageCategory()
        {
            var value = _MessageCategoryService.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var value = _MessageCategoryService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory MessageCategory)
        {
            _MessageCategoryService.TInsert(MessageCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            _MessageCategoryService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory MessageCategory)
        {
            _MessageCategoryService.TUpdate(MessageCategory);
            return Ok();
        }
    }
}
