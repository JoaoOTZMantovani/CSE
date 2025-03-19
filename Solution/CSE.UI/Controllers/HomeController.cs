using Microsoft.AspNetCore.Mvc;

namespace CSE.UI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
