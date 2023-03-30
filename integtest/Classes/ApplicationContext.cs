using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integtest.Classes
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Triangle> Triangle => Set<Triangle>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=123098;Database=Triangle");
        }
    }
}
