using Microsoft.AspNetCore.Mvc;

namespace WebServer;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}