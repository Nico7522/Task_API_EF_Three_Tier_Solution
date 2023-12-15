using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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

        public async Task<IEnumerable<TaskEntity>> GetTaskByPerson(int personId)
        {
           IEnumerable<TaskEntity> tasks = await _dc.Tasks.Join(_dc.TaskPerson, t => t.TaskId, tp => tp.TaskId, (t, tp) => new { t, tp }).Where(j => j.tp.PersonId == personId).Select(j => j.tp.Task).ToListAsync();
           return tasks;
        }

        public async Task<bool> ChangeStatus(TaskEntity task, bool newStatus)
        {
            task.IsCompleted = newStatus;
            int entriesNumber = await _dc.SaveChangesAsync();
            return (entriesNumber > 0) ? true : false;
        }

        public async Task<bool> AssignPerson(int[] personId, int taskId)
        {
            try
            {
                foreach (var id in personId)
                {
                    EntityEntry<TaskPersonEntity> t = _dc.TaskPerson.Add(new TaskPersonEntity()
                    {
                        PersonId = id,
                        TaskId = taskId
                    });
                }

                await _dc.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
