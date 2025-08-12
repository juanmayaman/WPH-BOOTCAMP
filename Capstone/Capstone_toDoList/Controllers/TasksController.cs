using Microsoft.AspNetCore.Mvc;

namespace Capstone_toDoList.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
