using HotelProject.BusinessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WepUI.Dtos.AppUserDto;
using HotelProject.WepUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WepUI.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //public async Task<IActionResult> Index()
        //{
        //    //var client = _httpClientFactory.CreateClient();
        //    //var responsemessage = await client.GetAsync("http://localhost:5202/api/AppUser");
        //    //if (responsemessage.IsSuccessStatusCode)
        //    //{
        //    //    var jsonData = await responsemessage.Content.ReadAsStringAsync();
        //    //    var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
        //    //    return View(values);
        //    //}
        //    return View();
        //}
        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5202/api/AppUser");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
