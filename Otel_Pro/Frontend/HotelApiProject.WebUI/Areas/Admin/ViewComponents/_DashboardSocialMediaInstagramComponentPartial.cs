using HotelApiProject.WebUI.Dtos.DashboardDtos.SocialMedia;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelApiProject.WebUI.Areas.Admin.ViewComponents
{
    public class _DashboardSocialMediaInstagramComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/a.m.c.sengor"),
                Headers =
    {
        { "x-rapidapi-key", "87ebda1640msh1f0710fdc6ebb78p11788djsnc07507e0fe79" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                InstagramFollowersDto followersDto = JsonConvert.DeserializeObject<InstagramFollowersDto>(body);
                return View(followersDto);
            }
        }
    }
}
