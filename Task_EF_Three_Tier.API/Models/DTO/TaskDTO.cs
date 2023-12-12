namespace Task_EF_Three_Tier.API.Models.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; }
        public string Title { get; }
        public string Description { get; }
        public bool IsCompleted { get; } = false;
        public TaskDTO(int taskId, string title, string description, bool isCompleted)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }

    }
}
