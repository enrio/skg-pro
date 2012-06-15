using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xMBSv2.Models.Entities
{
    using System.Data.Entity;

    public class ZContext : DbContext
    {
        public ZContext() : base("xMBSv2") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}