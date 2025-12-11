using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.ViewComponents.Default
{
    public class _ReservationPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
