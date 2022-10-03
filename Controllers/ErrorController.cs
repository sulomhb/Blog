using Microsoft.AspNetCore.Mvc;

namespace assignment_4.Controllers;

public class ErrorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}