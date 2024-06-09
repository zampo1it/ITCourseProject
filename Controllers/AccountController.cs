using ITProjectTryThree.Data;
using ITProjectTryThree.Models;
using ITProjectTryThree.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITProjectTryThree.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;


        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<IActionResult> UserPage(CollectionType? type, string id, string name = "default", int page = 1)
        {
            string userId;
            if (string.IsNullOrEmpty(id))
            {
                userId = User.GetUserId();
            }
            else
            {
                if (!name.Equals("default"))
                {
                    userId = User.GetUserId();
                }
                else userId = id;
            }
            string userNam = _context.Users.Find(userId).UserName;

            UserPageViewModel viewModel = new UserPageViewModel
            {
                UserName = _context.Users.Find(userId).UserName,
                Collections = _context.Collections.Where(m => m.Owner == userNam)
            };
            return View(viewModel);
        }
    }
}


public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}

