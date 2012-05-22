using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using Entities;
    using System.Data.Entity;

    public sealed class Context : DbContext
    {
        public DbSet<Pol_Role> Roles { get; set; }
        public DbSet<Pol_Right> Rights { get; set; }

        public DbSet<Pol_RoleRight> RoleRights { get; set; }
        public DbSet<Pol_UserRight> UserRights { get; set; }
        public DbSet<Pol_UserRole> UserRoles { get; set; }

        public DbSet<Pol_User> Users { get; set; }
        public DbSet<Tra_Group> Groups { get; set; }
        public DbSet<Tra_Kind> Kinds { get; set; }
        public DbSet<Tra_Vehicle> Vehicles { get; set; }
        public DbSet<Tra_Detail> Details { get; set; }

        public Context() : base("xBXEv1") { }
    }
}