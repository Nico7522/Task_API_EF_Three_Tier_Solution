using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.BLL.Interfaces;
using Task_API_EF_Three_Tier.DAL.Entities;
using ITaskRepositoryDAL =Task_API_EF_Three_Tier.DAL.Interfaces.ITaskRepository;
using IPersonRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces.IPersonRepository;
using Task_API_EF_Three_Tier.BLL.Utils;

namespace Task_API_EF_Three_Tier.BLL.Services
{
    public class PersonService : IPersonRepository
    {
    private readonly IPersonRepositoryDAL _personRepository;
    private readonly ITaskRepositoryDAL _taskRepository;

        public PersonService(IPersonRepositoryDAL personRepository, ITaskRepositoryDAL taskRepository)
        {
            _personRepository = personRepository;
            _taskRepository = taskRepository;
        }

        public async Task<int> Create(PersonEntity entity)
        {
           entity.EncodePassword();
           int id = await _personRepository.Create(entity);
           return id;
        }

        public async Task<bool> Delete(int id)
        {
            PersonEntity? person = await _personRepository.GetById(id);
            if (person is null) return false;

            bool isDeleted = await _personRepository.Delete(person);
            return isDeleted;
        }

        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
            return await _personRepository.GetAll();
        }

        public async Task<PersonEntity?> GetById(int id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task<bool> Update(int id, PersonEntity entity)
        {
            PersonEntity? oldPerson = await _personRepository.GetById(id);
            if (oldPerson is null) return false;

            bool isUpdated = await _personRepository.Update(oldPerson, entity);

            return isUpdated;
        }

        public async Task<IEnumerable<PersonEntity>> GetPersonByTask(int taskId)
        {
            TaskEntity? task = await _taskRepository.GetById(taskId);

            if (task is null) return null;

            IEnumerable<PersonEntity> people = await _personRepository.GetPersonByTask(taskId);
            return people;
        }
    }
}
