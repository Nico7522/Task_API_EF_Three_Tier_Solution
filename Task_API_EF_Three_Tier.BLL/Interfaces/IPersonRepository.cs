using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Entities;

namespace Task_API_EF_Three_Tier.BLL.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonEntity>> GetAll();
        Task<PersonEntity?> GetById(int id);
        Task<int> Create(PersonEntity entity);

        Task<bool> Update(int id,PersonEntity entity);

        Task<bool> Delete(int id);

        Task<IEnumerable<PersonEntity>> GetPersonByTask(int taskId);

        Task<PersonEntity?> GetPersonByEmail(string email);
    }
}
