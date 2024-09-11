using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserIdentityManagement.ViewModels;

namespace UserIdentityManagement.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public ManagerRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {

            if (!ModelState.IsValid)
                return View("Index", await _roleManager.Roles.ToListAsync());

            var roleIsExists = await _roleManager.RoleExistsAsync(model.Name);

            if (roleIsExists)
            {
                ModelState.AddModelError("Name", "Role is Exist!");
                return View("Index", await _roleManager.Roles.ToListAsync());
            }

            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));

            return RedirectToAction(nameof(Index));

        }
    }
}