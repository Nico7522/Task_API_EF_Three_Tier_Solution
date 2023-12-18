using Microsoft.EntityFrameworkCore;
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
    public class PersonService : IPersonRepository
    {
        private readonly DataContext _dc = new DataContext();
        public async Task<PersonEntity> Create(PersonEntity entity)
        {
            _dc.People.Add(entity);
            await _dc.SaveChangesAsync();
            PersonEntity newPerson = entity;
            return newPerson;
        }

        public async Task<bool> Delete(PersonEntity entity)
        {
            _dc.People.Remove(entity);
            int rows = await _dc.SaveChangesAsync();
            return rows == 1;
        }

        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
           return await _dc.People.ToListAsync();
        }

        public async Task<PersonEntity?> GetById(int id)
        {
            return await _dc.People.FindAsync(id);
        }

        public async Task<bool> Update(PersonEntity oldEntity,PersonEntity entity)
        {
            Method.UpdateEntity(oldEntity, entity, "FirstName", "LastName");
            int updatedRow = await _dc.SaveChangesAsync();
            return (updatedRow == 1) ? true : false;
        }

        public async Task<IEnumerable<PersonEntity>> GetPersonByTask(int taskId)
        {
            IEnumerable<PersonEntity> people = await _dc.People.Join(_dc.TaskPerson, p => p.PersonId, tp => tp.PersonId, (p , tp) => new {p , tp}).Where(j => j.tp.TaskId == taskId).Select(j => j.tp.Person).ToListAsync();
            return people;
        }

        public async Task<PersonEntity?> GetPersonByEmail(string email)
        {
            PersonEntity? person = await _dc.People.Where(p => p.Email == email).SingleOrDefaultAsync();
            return person;
        }

        public async Task<bool> UpdateAvatar(PersonEntity person, string imageName)
        {
            person.ImgUrl = imageName;
            int modifiedEntries = await _dc.SaveChangesAsync();
            return modifiedEntries == 1;
        }

        public async Task<PersonEntity?> Login(string email, string password)
        {
            PersonEntity? person = await _dc.People.Where(p => p.Email == email && p.Password == password).SingleOrDefaultAsync();
            return person;
        }
    }
}
