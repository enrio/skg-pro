using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    /// <summary>
    /// Cơ sở dữ liệu
    /// </summary>
    public class ZContext : DbContext
    {
        public DbSet<Tra_Group> Tra_Groups { get; set; }
        public DbSet<Tra_Kind> Tra_Kinds { get; set; }
        public DbSet<Tra_Vehicle> Tra_Vehicles { get; set; }
        public DbSet<Tra_Detail> Tra_Details { get; set; }

        public ZContext() : base("xSKGv1") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}