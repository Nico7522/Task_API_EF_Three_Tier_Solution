﻿using System;
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

        public IEnumerable<TaskEntity> GetAll()
        {
            IEnumerable<TaskEntity>? tasks = _taskRepository.GetAll();
            if (tasks is null) return null;

            return tasks;
        }

        public TaskEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}