using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_API_EF_Three_Tier.DAL.Interfaces;

namespace Task_API_EF_Three_Tier.DAL.Services
{
    public class PersonService : IPersonRepository
    {
        public Task<int> Create(PersonEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(PersonEntity id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, PersonEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
