﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_API_EF_Three_Tier.DAL.Entities
{
    public class PersonEntity
    {
        #nullable disable
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TaskPersonEntity> TaskTp { get; set; }
    }
}
