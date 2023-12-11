using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Entities;

namespace Task_API_EF_Three_Tier.DAL.Configs
{
    public class TaskPersonConfig : IEntityTypeConfiguration<TaskPersonEntity>
    {
        public void Configure(EntityTypeBuilder<TaskPersonEntity> builder)
        {
            builder.HasKey(tp => new { tp.TaskId, tp.PersonId });
            builder.HasOne(t => t.Task).WithMany(t => t.PersonTp).HasForeignKey(t => t.TaskId);
            builder.HasOne(p => p.Person).WithMany(p => p.TaskTp).HasForeignKey(p => p.PersonId);
        }
    }
}
