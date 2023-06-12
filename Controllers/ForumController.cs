using Microsoft.AspNetCore.Mvc;

namespace IBlogs.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Room()
        {
            return View();
        }
    }
}
