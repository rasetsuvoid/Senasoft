using Microsoft.AspNetCore.Mvc;

namespace Senasoft.Controllers
{
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}