namespace Capstone_toDoList.Models
{
    public class TaskItem
    {
        public int Id { get; set; } // Unique ID for the task
        public string Title { get; set; } // Short title
        public string Description { get; set; } 
        public string Subject { get; set; }
        public bool IsCompleted { get; set; } // Status
        public DateTime DueDate { get; set; } 
    }
}
