using HotelProject.EntityLayer.Concrete;
using HotelProject.WepUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            TempData["userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            var roleAssignViewModels = roles.Select(item => new RoleAssignViewModel
            {
                RoleID = item.Id,
                RoleName = item.Name,
                RoleExist = userRoles.Contains(item.Name)
            }).ToList();

            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model)
            {
                if (role.RoleExist && !userRoles.Contains(role.RoleName))
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else if (!role.RoleExist && userRoles.Contains(role.RoleName))
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }
}