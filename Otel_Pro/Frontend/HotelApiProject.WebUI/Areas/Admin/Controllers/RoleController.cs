using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.AppRoleDtos;
using HotelApiProject.WebUI.Dtos.AppUserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = _roleManager.Roles.ToList();
            var roles = _mapper.Map<List<RoleListDto>>(values);
            foreach (var role in roles)
            {
                var userInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                role.UserCount = userInRole.Count();
            }
            return View(roles);
        }
        [HttpGet]
        [Route("UserListByRole/{id:int}")]
        public async Task<IActionResult> UserListByRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var values = await _userManager.GetUsersInRoleAsync(role.Name);
            var map = _mapper.Map<List<UserListDto>>(values);
            ViewBag.role = role;
            return View(map);
        }
        [HttpGet]
        [Route("AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleAddDto dto)
        {
            var check = _roleManager.FindByNameAsync(dto.Name);
            if (!check.IsCompletedSuccessfully)
            {
                var map = _mapper.Map<AppRole>(dto);
                var result = await _roleManager.CreateAsync(map);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                }
                return RedirectToAction("AddRole");
            }
            else
            {
                return View();
            }

        }
        [Route("UpdateRole/{id:int}")]
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var map = _mapper.Map<RoleUpdateDto>(value);
            return View(map);
        }
        [HttpPost]
        [Route("UpdateRole/{id:int}")]
        public async Task<IActionResult> UpdateRole(RoleUpdateDto dto)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == dto.Id);
            role.Name = dto.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
            }
            return RedirectToAction("AddRole");
        }


        [HttpPost]
        [Route("DeleteRole/{id:int}")]
        public IActionResult DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }
    }

}
