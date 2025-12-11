using HotelProject.WepUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WepUI.ViewComponents.DashBoard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Staff Count
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5202/api/DashboardWidgets/StaffCount");
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            ViewBag.staffcount = jsonData;

            //Booking Count 
            var client1 = _httpClientFactory.CreateClient();
            var responsemessage1 = await client1.GetAsync("http://localhost:5202/api/DashboardWidgets/BookingCount");
            var jsonData1 = await responsemessage1.Content.ReadAsStringAsync();
            ViewBag.bookingcount = jsonData1;

            //AppUser Count 
            var client2 = _httpClientFactory.CreateClient();
            var responsemessage2 = await client2.GetAsync("http://localhost:5202/api/DashboardWidgets/AppUserCount");
            var jsonData2 = await responsemessage2.Content.ReadAsStringAsync();
            ViewBag.Usercount = jsonData2;

            //Room Count 
            var client3 = _httpClientFactory.CreateClient();
            var responsemessage3 = await client3.GetAsync("http://localhost:5202/api/DashboardWidgets/RoomCount");
            var jsonData3 = await responsemessage3.Content.ReadAsStringAsync();
            ViewBag.Roomcount = jsonData3;

            return View();
        }
    }
}
