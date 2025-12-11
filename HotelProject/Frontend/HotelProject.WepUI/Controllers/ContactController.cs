using HotelProject.WepUI.Dtos.BookingDto;
using HotelProject.WepUI.Dtos.ContactDto;
using HotelProject.WepUI.Dtos.MessageCategoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WepUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5202/api/MessageCategory");
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageCatogryDto>>(jsondata);
            List<SelectListItem> values2 = (from x in values
                                           select new SelectListItem
                                           {
                                               Text= x.MessageCategoryName,
                                               Value= x.MessageCategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values2;


            return View();
        }
        [HttpGet]

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]

        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5202/api/Contact", stringContent);

            return RedirectToAction("Index", "Default");
        }
    }
}
