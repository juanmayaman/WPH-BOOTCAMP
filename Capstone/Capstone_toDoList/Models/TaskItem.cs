namespace Capstone_toDoList.Models
{
    public class TaskItem
    {
        public int Id { get; set; } // Unique ID for the task
        public string Title { get; set; } // Short title
        public string Description { get; set; } 
        public string Category { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; } // Status
        public DateTime DateStarted { get; set; } // When the task was started
        public DateTime DueDate { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateDeleted { get; set; }
        public string AssignedTo { get; set; } // Name of person responsible
    }
}
