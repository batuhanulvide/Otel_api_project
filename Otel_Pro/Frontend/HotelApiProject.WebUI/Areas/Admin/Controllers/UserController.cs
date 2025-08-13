using AutoMapper;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.AppUserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class UserController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public UserController(UserManager<AppUser> userManager, IMapper mapper, IHttpClientFactory httpClientFactory, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _roleManager = roleManager;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _userManager.Users.Include(x => x.WorkLocation).ToList(); // Burada Include kullanıyorum fakat bunun yerine AppUser sınıfı içinde WorkLocation sınıfını public virtual olarak da tanımlarsam aynı işlevi görüyor. *-*
            var map = _mapper.Map<List<UserListDto>>(values);
            return View(map);
        }
        [HttpGet]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser()
        {
            var roles= _roleManager.Roles.ToList();
            List<SelectListItem> list= (from x in roles
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value=x.Id.ToString()
                                        }).ToList();
            ViewBag.roleList = list;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/WorkLocation");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<WorkLocation>>(jsonData);
            List<SelectListItem> workLocationList = (from x in values
                                                     select new SelectListItem
                                                     {
                                                         Text = x.WorkLocationName,
                                                         Value = x.WorkLocationId.ToString()
                                                     }).ToList();
            ViewBag.workLocation = workLocationList;
            return View();
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserAddDto dto, IFormFile Image)
        {
            var map = _mapper.Map<AppUser>(dto);

            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/users", imageName);
                var stream = new FileStream(saveLocation, FileMode.Create);
                await Image.CopyToAsync(stream);
                map.ImageUrl = $"/images/users/{imageName}";
            }
            else if (map.ImageUrl == null)
            {
                map.ImageUrl = $"/images/users/no-image-users.png";
            }


            //Rol ekleme işlemi--
            var newRole = _roleManager.Roles.FirstOrDefault(x => x.Id == dto.UserRole.Id);
            await _userManager.AddToRoleAsync(map, newRole.Name);
            //Rol ekleme işlemi--

            map.InstagramUrl = $"https://instagram.com/{map.InstagramUrl}";
            map.TwitterUrl = $"https://x.com/{map.TwitterUrl}";
            var result = await _userManager.CreateAsync(map, dto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(dto);
        }
        [HttpGet]
        [Route("UpdateUser/{id:int}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var value = await _userManager.FindByIdAsync(id.ToString());
            if (value != null)
            {
                var currentRole= await _userManager.GetRolesAsync(value);
                var roles = _roleManager.Roles.ToList();
                List<SelectListItem> roleList = (from x in roles
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString(),
                                                     Selected= currentRole.Contains(x.Name)
                                                 }).ToList();
                ViewBag.roleList = roleList;

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:5173/api/WorkLocation");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<WorkLocation>>(jsonData);
                List<SelectListItem> workLocationList = (from x in values
                                                         select new SelectListItem
                                                         {
                                                             Text = x.WorkLocationName,
                                                             Value = x.WorkLocationId.ToString()
                                                         }).ToList();
                ViewBag.workLocation = workLocationList;
                var map = _mapper.Map<UserUpdateDto>(value);
                return View(map);
            }
            return View();

        }
        [HttpPost]
        [Route("UpdateUser/{id:int}")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto memberUpdateDto, IFormFile Image)
        {
            var user = await _userManager.FindByIdAsync(memberUpdateDto.Id.ToString());
            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/users/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                memberUpdateDto.ImageUrl = $"/images/users/{imageName}";
                user.ImageUrl = memberUpdateDto.ImageUrl;
            }
            else if (user.ImageUrl == null)
            {
                user.ImageUrl = $"/images/users/no-image-users.png";
            }


            //Rol değiştirme işlemi--
            var currentRole = await _userManager.GetRolesAsync(user);
            var newRole = _roleManager.Roles.FirstOrDefault(x => x.Id == memberUpdateDto.UserRole.Id);
            await _userManager.RemoveFromRolesAsync(user, currentRole);
            await _userManager.AddToRoleAsync(user, newRole.Name);
            //Rol değiştirme işlemi--

            user.Name = memberUpdateDto.Name;
            user.Surname = memberUpdateDto.Surname;
            user.PhoneNumber = memberUpdateDto.PhoneNumber;
            user.About = memberUpdateDto.About;
            user.Email = memberUpdateDto.Email;
            user.Birtday = memberUpdateDto.Birtday;
            user.WorkLocationId = memberUpdateDto.WorkLocationId;
            user.Profession = memberUpdateDto.Profession;
            user.TwitterUrl = memberUpdateDto.TwitterUrl;
            user.Gender = memberUpdateDto.Gender;
            user.InstagramUrl = memberUpdateDto.InstagramUrl;
            if (memberUpdateDto.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, memberUpdateDto.Password);
                var result1 = await _userManager.UpdateAsync(user);
                if (result1.Succeeded)
                {
                    return View(memberUpdateDto);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                var result2 = await _userManager.UpdateAsync(user);
                if (result2.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }
        [Route("DeleteUser/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var value = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }
    }
}
