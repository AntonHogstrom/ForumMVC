using Microsoft.AspNetCore.Mvc;

namespace ForumMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // (HomeController är default)
        // /helloworld
        public IActionResult Index()
        {
            return View();
        }
        // /helloworld/hello
        public IActionResult Hello()
        {
            return View();
        }
    }
}
