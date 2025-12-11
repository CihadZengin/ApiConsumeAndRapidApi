using HotelProject.EntityLayer.Concrete;
using HotelProject.WepUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WepUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEdit = new UserEditViewModel();
            userEdit.Name = user.Name;
            userEdit.Surname = user.Surname;
            userEdit.Username = user.UserName;
            userEdit.Email = user.Email;
            return View(userEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (model.Password == model.ConfrimPassword)
            {

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View(); 
        }
    }
}
