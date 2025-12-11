using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.ViewComponents.DashBoard
{
    public class _DashboardHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
