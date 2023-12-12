using Task_API_EF_Three_Tier.DAL.Entities;
using Task_EF_Three_Tier.API.Models.DTO;

namespace Task_EF_Three_Tier.API.Mappers
{
    internal static class TaskMappers
    {

        internal static TaskDTO ToTaskDTO(this TaskEntity task) {

            return new TaskDTO(task.TaskId, task.Title, task.Description, task.IsCompleted);
        }
    }
}
