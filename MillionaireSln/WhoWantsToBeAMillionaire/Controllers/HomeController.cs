using Microsoft.AspNetCore.Mvc;

namespace WhoWantsToBeAMillionaire.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
