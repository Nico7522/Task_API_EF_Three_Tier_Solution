using Microsoft.EntityFrameworkCore;
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
    public class PersonService : IPersonRepository
    {
        private readonly DataContext _dc = new DataContext();
        public async Task<int> Create(PersonEntity entity)
        {
            _dc.People.Add(entity);
            await _dc.SaveChangesAsync();
            int id = entity.PersonId;
            return id;
        }

        public Task<bool> Delete(PersonEntity id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
           return await _dc.People.ToListAsync();
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
