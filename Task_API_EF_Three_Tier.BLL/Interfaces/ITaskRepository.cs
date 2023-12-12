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
        IEnumerable<TaskEntity> GetAll();
        TaskEntity GetById(int id);
    }
}
