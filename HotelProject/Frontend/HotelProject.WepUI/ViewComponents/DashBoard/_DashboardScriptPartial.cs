using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.ViewComponents.DashBoard
{
    public class _DashboardScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
