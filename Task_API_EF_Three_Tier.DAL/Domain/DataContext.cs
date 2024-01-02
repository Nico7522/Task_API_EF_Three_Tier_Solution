using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Configs;
using Task_API_EF_Three_Tier.DAL.Entities;

namespace Task_API_EF_Three_Tier.DAL.Domain
{
    public class DataContext : DbContext
    {
        private string _connectionString = "Data Source=GOS-VDI202\\TFTIC;Initial Catalog=Task_API_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;";

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<TaskPersonEntity> TaskPerson { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new TaskPersonConfig());
        }
    }
}
