using Task_API_EF_Three_Tier.DAL.Entities;
using Task_EF_Three_Tier.API.Models.DTO;
using Task_EF_Three_Tier.API.Models.Forms;

namespace Task_EF_Three_Tier.API.Mappers
{
    internal static class TaskMappers
    {

        internal static TaskDTO ToTaskDTO(this TaskEntity task) {

            return new TaskDTO(task.TaskId, task.Title, task.Description, task.IsCompleted);
        }

        internal static TaskEntity ToTaskEntity(this CreateTaskForm form)
        {
            return new TaskEntity()
            {
                Title = form.Title,
                Description = form.Description,
            };
        }
    }
}
