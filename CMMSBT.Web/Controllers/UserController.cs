using Microsoft.AspNetCore.Mvc;

namespace CMMSBT.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
