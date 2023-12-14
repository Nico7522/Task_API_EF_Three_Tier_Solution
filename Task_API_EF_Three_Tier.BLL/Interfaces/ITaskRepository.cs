using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Entities;

namespace Task_API_EF_Three_Tier.BLL.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>?> GetAll();
        Task<TaskEntity?> GetById(int id);

        Task<int> Create(TaskEntity entity);

        Task<bool> Update(int id, TaskEntity entity);

        Task<bool> Delete(int id);
        Task<IEnumerable<TaskEntity>?> GetTaskByPerson(int personId);
    }
}
