using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.ViewComponents.Default
{
    public class _TrailerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
