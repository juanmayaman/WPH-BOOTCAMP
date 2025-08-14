using System.Diagnostics;
using Capstone_toDoList.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_toDoList.Controllers
{
    public class TasksController : Controller
    {
        private static List<TaskItem> tasks = new List<TaskItem>(); //lists
        public IActionResult TasksLists()
        {
            return View(); 
        }
    }
}
