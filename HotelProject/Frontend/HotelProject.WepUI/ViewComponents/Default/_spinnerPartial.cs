using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.ViewComponents.Default
{
    public class _spinnerPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
