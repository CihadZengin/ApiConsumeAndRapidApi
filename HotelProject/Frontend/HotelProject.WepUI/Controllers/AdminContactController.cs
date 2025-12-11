using HotelProject.WepUI.Dtos.ContactDto;
using HotelProject.WepUI.Dtos.SendMessageDto;
using HotelProject.WepUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WepUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5202/api/Contact");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View();

        }

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5202/api/SendMessage");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.SenderMail = "admin@gmail.com";
            createSendMessageDto.SendrName = "admin";
            createSendMessageDto.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5202/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }

        public async Task <PartialViewResult> SideBarAdminContactPartial()
        {

            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5202/api/Contact/GetContactCount");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData;
                return PartialView();
            }
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        public async Task < IActionResult> MessageDetailsBySendBox(int id)
        {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5202/api/SendMessage/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                    return View(values);
                }
                return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5202/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        //public async Task<IActionResult> GetContactCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responsemessage = await client.GetAsync("http://localhost:5202/api/Contact/GetContactCount");
        //    if (responsemessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responsemessage.Content.ReadAsStringAsync();
        //        //var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
        //        ViewBag.data = jsonData;
        //        return View();
        //    }
        //    return View();
        //}
    }
}
