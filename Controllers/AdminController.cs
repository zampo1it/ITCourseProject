using ITProjectTryThree.Data;
using ITProjectTryThree.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ITProjectTryThree.Controllers
{
	//[Authorize(Roles = "admin")]
	public class AdminController : Controller
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AdminController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_context = context;
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<IActionResult> Index()
		{
			var response = await GetUserTable();
			return View(response);
		}

		private async Task<AdminViewModel> GetUserTable()
		{
			var users = _context.Users.ToList();
			var roles = new List<string>();
			for (int i = 0; i < users.Count(); i++)
			{
				var role = await _userManager.GetRolesAsync(users[i]);
				if (role.Count() != 0)
				{
					if (role[0] == "admin")
					{
						roles.Add(role[0]);
						continue;
					}
					roles.Add("user");
					continue;
				}
				roles.Add("user");
			}

			var response = new AdminViewModel()
			{
				Roles = roles,
				Users = users
			};
			return response;
		}

		public async Task<IActionResult> Block(string id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user != null)
			{
				user.LockoutEnabled = true;
				user.LockoutEnd = DateTime.Now.AddYears(100);
				_context.Users.Update(user);
				await _context.SaveChangesAsync();
			}

			if (user.UserName == User.Identity.Name)
			{
				await _signInManager.SignOutAsync();
			}
			return RedirectToAction("Index", "Admin");
		}

		public async Task<IActionResult> Unblock(string id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user != null)
			{
				user.LockoutEnabled = false;
				user.LockoutEnd = DateTime.Now;
				_context.Users.Update(user);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction("Index", "Admin");
		}

		public async Task<IActionResult> ChangeRole(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user != null)
			{
				var role = await _userManager.GetRolesAsync(user);
				if (role.Count() == 0)
				{
					await _userManager.AddToRoleAsync(user, "admin");
					return RedirectToAction("Index", "Admin");
				}
				if (role[0] == "admin")
				{
					await _userManager.RemoveFromRoleAsync(user, "admin");
					await _userManager.AddToRoleAsync(user, "user");
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(user, "user");
					await _userManager.AddToRoleAsync(user, "admin");
				}

			}

			if (user.UserName == User.Identity.Name)
			{
				await _signInManager.SignOutAsync();
			}
			return RedirectToAction("Index", "Admin");
		}

		public async Task<IActionResult> Delete(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user != null)
			{
				var collections = _context.Collections.Where(m => m.Owner == user.UserName);
				foreach (var c in collections)
				{
					await DeleteCollection(c.id);
				}

				if (user.UserName == User.Identity.Name)
				{
					await _signInManager.SignOutAsync();
				}

				_context.Users.Remove(user);
				_context.SaveChanges();
			}
			return RedirectToAction("Index", "Admin");
		}


		private async Task<IActionResult> DeleteCollection(int id)
		{
			var collection = _context.Collections.FirstOrDefault(m => m.id == id);
			if (collection != null)
			{
				var items = _context.Items.Where(m => m.CollectionId == collection.id).ToList();
				foreach (var item in items)
				{
					_context.Items.Remove(item);
				}
				_context.Collections.Remove(collection);
			}
			return Content("ok");
		}
	}
}
