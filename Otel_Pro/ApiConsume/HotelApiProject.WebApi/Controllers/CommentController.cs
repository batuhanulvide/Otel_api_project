using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _CommentService;

        public CommentController(ICommentService CommentService)
        {
            _CommentService = CommentService;
        }

        [HttpGet]
        public IActionResult ListComment()
        {
            var value = _CommentService.TGetCommentList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _CommentService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetCommentListByRoomId/{id:int}")]
        public IActionResult GetCommentListByRoomId(int id)
        {
            var value = _CommentService.TGetCommentListByRoomId(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddComment(Comment Comment)
        {
            _CommentService.TInsert(Comment);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            _CommentService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment Comment)
        {
            _CommentService.TUpdate(Comment);
            return Ok();
        }
    }
}
