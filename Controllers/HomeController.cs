using Microsoft.AspNetCore.Mvc;

namespace CoderHouseProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
