using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Domain;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_API_EF_Three_Tier.DAL.Interfaces;

namespace Task_API_EF_Three_Tier.DAL.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _dc = new DataContext();
        public int Create(TaskEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            IEnumerable<TaskEntity>? tasks = _dc.Tasks;

            return tasks;
        }

        public TaskEntity GetById(int id)
        {
            TaskEntity? task = _dc.Tasks.Find(id);
            return task;
        }

        public bool Update(int id, TaskEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
