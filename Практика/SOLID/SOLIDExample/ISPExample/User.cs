using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPExample
{
    public class User (int id, Memberships membership)
    {
        public int Id { get; } = id;
        public Memberships Membership { get; } = membership;
    }
}
