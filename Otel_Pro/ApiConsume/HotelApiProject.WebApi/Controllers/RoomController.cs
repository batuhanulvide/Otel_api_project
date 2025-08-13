using AutoMapper;
using AutoMapper.Configuration.Annotations;
using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.DtoLayer.Dtos.RoomDtos;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace HotelApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService RoomService, IMapper mapper)
        {
            _RoomService = RoomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListRoom()
        {
            var value = _RoomService.TGetList();         
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var value = _RoomService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var map = _mapper.Map<Room>(dto);
            _RoomService.TInsert(map);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            _RoomService.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }          
            var map = _mapper.Map<Room>(dto);
            _RoomService.TUpdate(map);
            return Ok("Başarıyla güncellendi.");
        }

    }
}
