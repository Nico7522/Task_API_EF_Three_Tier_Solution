using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITaskRepositoryBLL = Task_API_EF_Three_Tier.BLL.Interfaces.ITaskRepository;
using Task_API_EF_Three_Tier.DAL.Entities;
using ITaskRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces.ITaskRepository;

namespace Task_API_EF_Three_Tier.BLL.Services
{
    public class TaskService : ITaskRepositoryBLL
    {
        private readonly ITaskRepositoryDAL _taskRepository;

        public TaskService(ITaskRepositoryDAL taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> Create(TaskEntity entity)
        {
           int id = await _taskRepository.Create(entity);
            return id;
        }

        public async Task<bool> Delete(int id)
        {
            TaskEntity? taskToDelete = await _taskRepository.GetById(id);
            if (taskToDelete is null) return false;
            bool isDeleted = await _taskRepository.Delete(taskToDelete);
            return isDeleted;
        }

        public async Task<IEnumerable<TaskEntity>?> GetAll()
        {
            IEnumerable<TaskEntity>? tasks = await _taskRepository.GetAll();
            if (tasks is null) return null;

            return tasks;
        }

        public async Task<TaskEntity?> GetById(int id)
        {
            TaskEntity? task = await _taskRepository.GetById(id);
            if (task is null) return null;

            return task;
        }

        public async Task<bool> Update(int id, TaskEntity entity)
        {
            TaskEntity? oldTask = await _taskRepository.GetById(id);
            if (oldTask is null) return false;
            bool isUpdated = await _taskRepository.Update(oldTask, entity);
            
            return isUpdated;
        }
    }
}
