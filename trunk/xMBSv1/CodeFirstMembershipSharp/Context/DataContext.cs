using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CodeFirstMembershipSharp
{
    public class DataContext : DbContext
    {
        public DataContext() : base("xMBSv1") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}