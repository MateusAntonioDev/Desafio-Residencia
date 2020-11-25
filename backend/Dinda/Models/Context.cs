using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dinda.Models
{
    public class Context : DbContext
    {
        public DbSet<Conhecimentos> Conhecimentos { get; set; }
        public DbSet<Madrinhas> Madrinhas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(connectionString:@"Server=(localdb)\mssqllocaldb;Database=Dinda;Integrated Security=True");
        }
    }
}
