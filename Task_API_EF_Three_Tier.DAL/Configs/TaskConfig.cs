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
    public class TaskConfig : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(t => t.TaskId);
            builder.Property(t => t.TaskId).ValueGeneratedOnAdd();
            builder.Property(t => t.Title).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(300).IsRequired();
            builder.Property(t => t.IsCompleted).HasDefaultValue(false);
        }
    }
}
