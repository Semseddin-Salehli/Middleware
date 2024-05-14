using Microsoft.AspNetCore.Mvc;
using Middleware.Models;
using System.Diagnostics;

namespace Middleware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MiddlewareTaskContext _context;

        public HomeController(ILogger<HomeController> logger, MiddlewareTaskContext context)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog enjected into HomeController");
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string text)
        {
            _logger.LogInformation("HomeController: Post method called!");


            return RedirectToAction(nameof(Index));
        }
    }
}
