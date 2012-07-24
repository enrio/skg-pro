#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 24/07/2012 21:32
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
    /// Database structure of system
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Policy - List all of actions: Add, Edit, Delete, Print, ... on menuz or form
        /// </summary>
        public DbSet<Pol_Action> Pol_Actions { get; set; }

        /// <summary>
        /// Policy - List role of user group
        /// </summary>
        public DbSet<Pol_Role> Pol_Roles { get; set; }

        /// <summary>
        /// Policy - All menuz, form of system
        /// </summary>
        public DbSet<Pol_Right> Pol_Rights { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Pol_User> Pol_Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Pol_UserRole> Pol_UserRoles { get; set; }

        /// <summary>
        /// Policy - Language for system (include all form, menuz and more)
        /// </summary>
        public DbSet<Pol_Lang> Pol_Langs { get; set; }

        /// <summary>
        /// Using string connection from App.Config file
        /// </summary>
        public Context() : base("xSKGv1") { }

        /// <summary>
        /// One to many cascade delete convention
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}