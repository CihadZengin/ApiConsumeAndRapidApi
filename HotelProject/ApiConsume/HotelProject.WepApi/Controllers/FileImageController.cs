using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        public class FileUpload
        {
            public IFormFile File { get; set; }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] FileUpload fileUpload)
        {
            var filename = Guid.NewGuid()+Path.GetExtension(fileUpload.File.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Images/"+ filename);
            var stream = new FileStream(path, FileMode.Create);
            await fileUpload.File.CopyToAsync(stream);
            return Created("", fileUpload);
        }
    }
}
