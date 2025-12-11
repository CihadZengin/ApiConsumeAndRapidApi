using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
