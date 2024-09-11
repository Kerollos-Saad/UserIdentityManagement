using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserIdentityManagement.Models;
using UserIdentityManagement.ViewModels;

namespace UserIdentityManagement.Controllers
{
	[Authorize(Roles = "Manager")]
	public class UsersController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UsersController(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
		{
			this._userManager = _userManager;
			this._roleManager = _roleManager;
		}

		public async Task<IActionResult> Index()
		{
			var users = await _userManager.Users.Select(user => new UserViewModel
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Email = user.Email,
				Roles = _userManager.GetRolesAsync(user).Result
			}).ToListAsync();

			return View(users);
		}

		public async Task<IActionResult> ManageRoles(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
				return NotFound();

			var roles = await _roleManager.Roles.ToListAsync();

			var viewModel = new UserRolesViewModel
			{
				UserId = user.Id,
				UserName = user.UserName,
				Roles = roles.Select(role => new RoleViewModel
				{
					RoleName = role.Name,
					IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
				}).ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId);

			if (user == null)
				return NotFound();

			var userRoles = await _userManager.GetRolesAsync(user);

			foreach (var role in model.Roles)
			{
				if (role.IsSelected && !userRoles.Any(r => r == role.RoleName))
					await _userManager.AddToRoleAsync(user, role.RoleName);

				if (!role.IsSelected && userRoles.Any(r => r == role.RoleName))
					await _userManager.RemoveFromRoleAsync(user, role.RoleName);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
