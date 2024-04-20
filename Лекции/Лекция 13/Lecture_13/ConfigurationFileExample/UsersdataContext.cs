using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationFileExample
{
    public partial class UsersdataContext : DbContext
    {
        public UsersdataContext()
        {
        }

        public UsersdataContext(DbContextOptions<UsersdataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
