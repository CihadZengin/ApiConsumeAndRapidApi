using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WepUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)

        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType ?? "application/octet-stream");

            var multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            using var httpclient = new HttpClient();
            var response = await httpclient.PostAsync("http://localhost:5202/api/FileProcess", multipartFormDataContent);

            return View();

        }
    }
}
