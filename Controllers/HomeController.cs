using ITProjectTryThree.Data;
using ITProjectTryThree.Models;
using ITProjectTryThree.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;

namespace ITProjectTryThree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpPost]
        public IActionResult SaveCheckboxValue(bool value)
        {
            _context.isDarkTheme = value;
            return Ok();
        }

        public async Task<IActionResult> ChangeCulture(string culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
            Response.Cookies.Append("Culture", culture);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Index()
        {
            await CreateAdminRole();
			var collection = await _context.Collections.OrderBy(c => c.Date).Reverse().ToListAsync();
            var count = await _context.Items.CountAsync();
            var items = await _context.Items.ToListAsync();
            HomeViewModel viewModel = new HomeViewModel
            {
                UserId = User.GetUserId(),
                Collections = collection.Take(5).ToList(),
                Items = Enumerable.Reverse(items).Take(5).ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Search(string query)
        {
            var countCollections = await _context.Collections.CountAsync();
            var collection = await _context.Collections
                .Where(c => c.Title.Contains(query))
                .OrderBy(c => c.Date)
                .Reverse()
                .ToListAsync();

            var countItems = await _context.Items.CountAsync();

            List<Item> items = new List<Item>();
            if (query == null)
            {
				return RedirectToAction("Index", "Home");
			}
            if (query.StartsWith("#"))
            {
                items = await _context.Items
                .Where(c => c.TagsList.Contains(query))
                .ToListAsync();
            }
            else
            {
                items = await _context.Items
                .Where(c => c.Title.Contains(query))
                .ToListAsync();
            }

            SearchViewModel viewModel = new SearchViewModel
            {
                SearchString = query,
                Collections = collection.ToList(),
                Items = items.ToList()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Collections()
        {
            return RedirectToAction("Index", "Collections");
        }
        public IActionResult UserPage()
        {
            return View();
        }

		public async Task<IActionResult> CreateAdminRole()
		{
			IdentityRole identityRole = new IdentityRole
			{
				Name = UserRoles.Admin,
				NormalizedName = "ADMIN"
			};
			if (!_context.Roles.Any(r => r.Name == UserRoles.Admin))
				_context.Roles.Add(identityRole);

			IdentityRole identityRole1 = new IdentityRole
			{
				Name = UserRoles.User,
				NormalizedName = "USER"
			};
            if (!_context.Roles.Any(r => r.Name == UserRoles.User))
			    _context.Roles.Add(identityRole1);
			await _context.SaveChangesAsync();
			return Content("ok");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
