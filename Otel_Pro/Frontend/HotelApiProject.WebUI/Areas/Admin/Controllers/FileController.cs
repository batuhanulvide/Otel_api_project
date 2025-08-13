using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class FileController : Controller
    {
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(byteArrayContent, "file", file.FileName);
            var httpClient = new HttpClient();
            await httpClient.PostAsync("http://localhost:5173/api/FileUpload", content);
            return RedirectToAction("Index");
        }

    }
}
