using Capstone_toDoList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone_toDoList.Controllers
{
    public class TasksController : Controller
    {

        private static List<TaskItem> tasks = new List<TaskItem>();

        // Show task list
        public IActionResult TasksLists()
        {
            return View(tasks); // pass tasks to view
        }

        // Add task
        [HttpPost]
        public IActionResult AddTask(TaskItem task)
        {

            if (task.DueDate < DateTime.Today)
            {
                TempData["Error"] = "Due date cannot be in the past.";
                return RedirectToAction("TasksLists");
            }
            task.Id = tasks.Count + 1;
            task.IsCompleted = false;
            task.DateStarted = DateTime.Today; //started date

            /*
                Critical-same day,1 day duedate
                High - 2-4days from now
                Medium - 5 -8 days
                Low - 9 days above
             */

            var daysLeft = (task.DueDate - DateTime.Today).Days;
            if (daysLeft <= 1 && daysLeft >= 0) task.Priority = "Critical";
            else if (daysLeft <= 4) task.Priority = "High";
            else if (daysLeft <= 8) task.Priority = "Medium";
            else task.Priority = "Low";

            tasks.Add(task);

            return RedirectToAction("TasksLists"); 
        }

    }
}
