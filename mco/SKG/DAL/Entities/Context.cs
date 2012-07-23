#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 23/07/2012 22:50
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    /// <summary>
    /// Database structure
    /// </summary>
    public class Context : DbContext
    {
        public DbSet<Pol_Action> Pol_Actions { get; set; }
        public DbSet<Pol_Role> Pol_Roles { get; set; }
        public DbSet<Pol_Right> Pol_Rights { get; set; }
        public DbSet<Pol_User> Pol_Users { get; set; }
        public DbSet<Pol_RoleRight> Pol_RoleRights { get; set; }
        public DbSet<Pol_UserRight> Pol_UserRights { get; set; }
        public DbSet<Pol_UserRole> Pol_UserRoles { get; set; }
        public DbSet<Pol_Lang> Pol_Langs { get; set; }

        public Context() : base("xSKGv1") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}