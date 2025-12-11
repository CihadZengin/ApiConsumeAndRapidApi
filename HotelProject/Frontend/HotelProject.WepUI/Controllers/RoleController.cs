using HotelProject.EntityLayer.Concrete;
using HotelProject.WepUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WepUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task  <IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole appRole=new AppRole()
            {
                Name = addRoleViewModel.RoleName
            };
            var result =await _roleManager.CreateAsync(appRole);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleModel updateRoleModel = new UpdateRoleModel()
            {
                RoleID = value.Id,
                RoleName = value.Name
            };
            return View(updateRoleModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleModel updateRoleModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleModel.RoleID);
            value.Name=updateRoleModel.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }

    }
}
