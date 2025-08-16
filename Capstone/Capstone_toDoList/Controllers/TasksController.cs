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
            task.Id = tasks.Count + 1;
            task.IsCompleted = false;

            //need calculate yung priority level
            /*
                Critical-same day,1 day duedate
                High - 2-4days from now
                Medium - 5 -8 days
                Low - 9 days above
             */
            //for due date validation?
            /*if (task.DueDate < DateTime.Today)
            {
                ModelState.AddModelError("DueDate", "Due date cannot be in the past.");
                return View(task);
            }*/


            tasks.Add(task);

            return RedirectToAction("TasksLists"); 
        }


    }
}
