using Microsoft.AspNetCore.Mvc;

namespace Watchlist.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
