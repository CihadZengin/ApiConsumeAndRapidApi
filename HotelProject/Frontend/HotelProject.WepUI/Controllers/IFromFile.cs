
using System.Net.Http.Headers;

namespace HotelProject.WepUI.Controllers
{
    public interface IFromFile
    {
        MediaTypeHeaderValue ContenType { get; }
        MediaTypeHeaderValue ContentType { get; }
        string FileName { get; }

        Task CopyToAsync(MemoryStream stream);
    }
}