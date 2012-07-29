using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.DAL.Entities
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class Context : DbContext
    {
        public DbSet<Tra_Group> Tra_Groups { get; set; }
        public DbSet<Tra_Kind> Tra_Kinds { get; set; }
        public DbSet<Tra_Vehicle> Tra_Vehicles { get; set; }
        public DbSet<Tra_Detail> Tra_Details { get; set; }

        public Context() : base("xSKGv1") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}