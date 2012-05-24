using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class Context : DbContext
    {
        public DbSet<Pol_Action> Pol_Actions { get; set; }
        public DbSet<Pol_Role> Pol_Roles { get; set; }
        public DbSet<Pol_Right> Pol_Rights { get; set; }
        public DbSet<Pol_User> Pol_Users { get; set; }
        public DbSet<Pol_RoleRight> Pol_RoleRights { get; set; }
        public DbSet<Pol_UserRight> Pol_UserRights { get; set; }
        public DbSet<Pol_UserRole> Pol_UserRoles { get; set; }

        public DbSet<Tra_Group> Tra_Groups { get; set; }
        public DbSet<Tra_Kind> Tra_Kinds { get; set; }
        public DbSet<Tra_Vehicle> Tra_Vehicles { get; set; }
        public DbSet<Tra_Detail> Tra_Details { get; set; }

        public Context() : base("xBXEv1") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}