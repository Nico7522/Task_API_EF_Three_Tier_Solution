using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.BLL.Interfaces;
using Task_API_EF_Three_Tier.DAL.Entities;
using IPersonRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces.IPersonRepository;

namespace Task_API_EF_Three_Tier.BLL.Services
{
    public class PersonService : IPersonRepository
    {
    private readonly IPersonRepositoryDAL _personRepository;

        public PersonService(IPersonRepositoryDAL personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<int> Create(PersonEntity entity)
        {
           int id = await _personRepository.Create(entity);
           return id;
        }

        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
            return await _personRepository.GetAll();
        }
    }
}
