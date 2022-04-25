using Microsoft.AspNetCore.Mvc;

namespace HangmanOnline.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
