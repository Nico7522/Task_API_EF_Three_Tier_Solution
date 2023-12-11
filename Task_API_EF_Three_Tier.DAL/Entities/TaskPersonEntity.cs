using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_API_EF_Three_Tier.DAL.Entities
{
    public class TaskPersonEntity
    {
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
