using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.CommentDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebUI.ViewComponents
{
    public class _DefaultRoomDetailMakeCommentComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public _DefaultRoomDetailMakeCommentComponentPartial(IHttpClientFactory httpClientFactory, IMapper mapper, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            if (User.Identity.Name == null)
            {
                return View();
            }
            else
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                CommentAddDto commentAddDto = new CommentAddDto();
                commentAddDto.UserId = user.Id;
                commentAddDto.RoomId = id;
                return View(commentAddDto);
            }

        }
    }
}
