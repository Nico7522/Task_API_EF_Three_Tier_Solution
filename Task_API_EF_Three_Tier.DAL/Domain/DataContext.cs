using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Configs;

namespace Task_API_EF_Three_Tier.DAL.Domain
{
    public class DataContext : DbContext
    {
        private string _connectionString = "Data Source=DESKTOP-IFNFMI9;Initial Catalog=Task_EF_Three_Tier;Integrated Security=True;Connect Timeout=60;Encrypt=False;";

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
