﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Domain;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_API_EF_Three_Tier.DAL.Interfaces;
using Task_API_EF_Three_Tier.DAL.Utils;

namespace Task_API_EF_Three_Tier.DAL.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _dc = new DataContext();
        public async Task<int> Create(TaskEntity entity)
        {
            _dc.Add(entity);
            await _dc.SaveChangesAsync();
            int id = entity.TaskId;
            return id;
        }

        public async Task<bool> Delete(TaskEntity task)
        {
            _dc.Tasks.Remove(task);
            int rows = await _dc.SaveChangesAsync();
            return rows == 1;

        }

        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            IEnumerable<TaskEntity>? tasks = await _dc.Tasks.ToListAsync();

            return tasks;
        }

        public async Task<TaskEntity?> GetById(int id)
        {
            TaskEntity? task = await _dc.Tasks.FindAsync(id);
            if (task is null) return null;
            return task;
        }

        public async Task<bool> Update(TaskEntity oldEntity, TaskEntity entity)
        {
            Method.UpdateEntity(oldEntity, entity, "Title", "Description");
            int entriesNumber = await _dc.SaveChangesAsync();
            return (entriesNumber > 0) ? true : false;

        }
     
    }
}
