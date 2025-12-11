using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.ViewComponents.Default
{
    public class _ScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
