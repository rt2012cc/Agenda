using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        [Route("Contatos/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Sobre";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Entre em Contato :";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
