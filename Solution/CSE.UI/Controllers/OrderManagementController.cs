using Microsoft.AspNetCore.Mvc;

namespace CSE.UI.Controllers;

public class OrderManagementController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateOrder()
    {
        ViewBag.UserName = "João Mantovani";

        return View();
    }

}
