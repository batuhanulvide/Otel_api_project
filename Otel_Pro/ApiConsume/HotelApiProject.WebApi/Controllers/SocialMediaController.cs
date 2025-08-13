using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;

        public SocialMediaController(ISocialMediaService SocialMediaService)
        {
            _SocialMediaService = SocialMediaService;
        }

        [HttpGet]
        public IActionResult ListSocialMedia()
        {
            var value = _SocialMediaService.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia SocialMedia)
        {
            _SocialMediaService.TInsert(SocialMedia);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            _SocialMediaService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(SocialMedia SocialMedia)
        {
            _SocialMediaService.TUpdate(SocialMedia);
            return Ok();
        }
    }
}
