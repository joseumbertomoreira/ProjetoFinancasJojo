using Microsoft.AspNetCore.Mvc;

namespace MainProject.Controllers;

public class HomeController : Controller
{
    

    public ActionResult Index()
    {
        return View();
    }

}