using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Hosting;

namespace AuthRequirementExample
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Home");
        }

        // /Home/BottlesOfBeerOnTheWall/99
        [Authorize(Policy = "99bottles")]
        public IActionResult BottlesOfBeerOnTheWall(string id)
        {
            return Content("you're in!");
        }
    }
}
