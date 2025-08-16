using Capstone_toDoList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone_toDoList.Controllers
{
    public class TasksController : Controller
    {

        private static List<TaskItem> tasks = new List<TaskItem>();
        private static List<TaskItem> completed = new List<TaskItem>();
        private static List<TaskItem> deleted = new List<TaskItem>();

        // Show task list
        public IActionResult TasksLists()
        {
            return View(tasks); // pass tasks to view
        }

        public IActionResult Completed()
        {
            return View(completed); // pass completed tasks to view
        }

        public IActionResult Deleted()
        {
            return View(deleted); // pass deleted to view
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

            //priority
            var daysLeft = (task.DueDate - DateTime.Today).Days;
            if (daysLeft <= 1 && daysLeft >= 0) task.Priority = "Critical";
            else if (daysLeft <= 4) task.Priority = "High";
            else if (daysLeft <= 8) task.Priority = "Medium";
            else task.Priority = "Low";

            tasks.Add(task);

            return RedirectToAction("TasksLists"); 
        }

        [HttpPost]
        public IActionResult CompleteTask(int taskId)
        {
            // Find the task by Id
            var task = tasks.FirstOrDefault(t => t.Id == taskId);

            // Mark as completed
            task.IsCompleted = true;
            task.DateCompleted = DateTime.Now;

            tasks.Remove(task);
            completed.Add(task);

            // Redirect to Tasks list or Completed tasks view
            return RedirectToAction("Completed");
        }

        [HttpPost]
        public IActionResult DeleteTask(int taskId)
        {
            // Find the task
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                TempData["Error"] = "Task not found.";
                return RedirectToAction("TasksLists");
            }

            // Set deleted date
            task.DateDeleted = DateTime.Now;

            // Move to deleted list
            tasks.Remove(task);
            deleted.Add(task);

            // Redirect to Deleted tasks view
            return RedirectToAction("Deleted");
        }

    }
}
