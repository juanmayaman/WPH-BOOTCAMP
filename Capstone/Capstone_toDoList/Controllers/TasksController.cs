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
        public IActionResult TasksLists(string searchString = null, string priority = null, string category = null, string sortBy = null)
        {
            var filteredTasks = tasks.AsQueryable();

            // Search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                filteredTasks = filteredTasks.Where(t =>
                    t.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    t.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    t.Category.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    t.AssignedTo.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            // Priority filter
            if (!string.IsNullOrEmpty(priority))
            {
                filteredTasks = filteredTasks.Where(t => t.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase));
            }

            // Category filter
            if (!string.IsNullOrEmpty(category))
            {
                filteredTasks = filteredTasks.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            // Sorting by Due Date
            if (sortBy == "near")
            {
                filteredTasks = filteredTasks.OrderBy(t => t.DueDate);
            }
            else if (sortBy == "far")
            {
                filteredTasks = filteredTasks.OrderByDescending(t => t.DueDate);
            }

            return View(filteredTasks.ToList());
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

        //delete task
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
        //SHOW PREVIOUS DATA
        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                TempData["Error"] = "Task not found.";
                return RedirectToAction("TasksLists");
            }

            return View(task); // pass task to the Edit view
        }
        //EDIT BAGO
        [HttpPost]
        public IActionResult UpdateTask(TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (task == null)
            {
                TempData["Error"] = "Task not found.";
                return RedirectToAction("TasksLists");
            }

            // Update properties
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Category = updatedTask.Category;
            task.DueDate = updatedTask.DueDate;
            task.AssignedTo = updatedTask.AssignedTo;

            // Optional: update priority based on DueDate
            var daysLeft = (task.DueDate - DateTime.Today).Days;
            if (daysLeft <= 1 && daysLeft >= 0) task.Priority = "Critical";
            else if (daysLeft <= 4) task.Priority = "High";
            else if (daysLeft <= 8) task.Priority = "Medium";
            else task.Priority = "Low";

            return RedirectToAction("TasksLists");
        }

        //restore task
        [HttpPost]
        public IActionResult RestoreTask(int taskId)
        {
            // Find the task in the deleted list
            var task = deleted.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                TempData["Error"] = "Task not found in deleted tasks.";
                return RedirectToAction("Deleted");
            }

            // Reset completion/deletion properties
            task.IsCompleted = false;
            task.DateCompleted = null;
            task.DateDeleted = null;

            // Remove from deleted and add back to active tasks
            deleted.Remove(task);
            tasks.Add(task);

            return RedirectToAction("TasksLists");
        }
    }
}
