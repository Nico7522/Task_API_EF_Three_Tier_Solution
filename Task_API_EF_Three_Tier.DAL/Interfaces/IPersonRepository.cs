﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Entities;

namespace Task_API_EF_Three_Tier.DAL.Interfaces
{
    public interface IPersonRepository : ICrudRepository<int, PersonEntity>
    {
        Task<IEnumerable<PersonEntity>> GetPersonByTask(int taskId);

        Task<PersonEntity?> GetPersonByEmail(string email);

        Task<bool> UpdateAvatar(PersonEntity person, string imageName);

        Task<PersonEntity?> Login (string email, string password);
    }
}
