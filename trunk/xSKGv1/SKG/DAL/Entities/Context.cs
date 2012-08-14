#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 26/07/2012 14:22
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
        /// Policy - Language for system (include all form, menuz and more)
        /// </summary>
        public DbSet<Pol_Dictionary> Pol_Dictionarys { get; set; }

        /// <summary>
        /// Policy - User's information
        /// </summary>
        public DbSet<Pol_User> Pol_Users { get; set; }

        /// <summary>
        /// Policy - List of user right on menuz or form
        /// </summary>
        public DbSet<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// Policy - User's list has permission
        /// </summary>
        public DbSet<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// Policy - List of user belong group
        /// </summary>
        public DbSet<Pol_UserRole> Pol_UserRoles { get; set; }

        /// <summary>
        /// Policy - Chat on system
        /// </summary>
        public DbSet<Pol_Chat> Pol_Chats { get; set; }

        /// <summary>
        /// Policy - User's language choice
        /// </summary>
        public DbSet<Pol_Selection> Pol_UserLangs { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Tra_Joining> Tra_Adherences { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Tra_Kind> Tra_Kinds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Tra_Vehicle> Tra_Vehicles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Tra_Detail> Tra_Details { get; set; }
    }
}