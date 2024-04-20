using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDataBaseExample
{
    public class UsersDataBaseContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public UsersDataBaseContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=usersdata.db");
        }
    }
}
