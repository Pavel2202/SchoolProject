namespace Warehouse.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using Warehouse.Models;

    public class HomeController : Controller
    {
        public IActionResult Index()
            => this.View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}