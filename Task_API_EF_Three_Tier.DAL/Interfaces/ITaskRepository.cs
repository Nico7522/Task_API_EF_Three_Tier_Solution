using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Entities;

namespace Task_API_EF_Three_Tier.DAL.Interfaces
{
    public interface ITaskRepository : ICrudRepository<int, TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTaskByPerson(int personId);
        Task<bool> ChangeStatus(TaskEntity task, bool newStatus);
    }
}
