using Microsoft.AspNetCore.Mvc;

namespace ITProjectTryThree.Controllers
{
    public class ErrorController : Controller
    {
        public async Task<IActionResult> NotFound()
        {
            return View("NotFound");
        }
    }
}
