using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using Entities;
    using System.Data.Entity;

    public sealed class Context : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Right> Rights { get; set; }

        public DbSet<RoleRight> RoleRights { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Detail> Details { get; set; }

        public Context() : base("xBXEv1") { }
    }
}