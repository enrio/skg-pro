using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXE.DAL.Entities
{
    using SKG.UTL;
    using SKG.DAL;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ZContext : SKG.DAL.Entities.SContext
    {
        public DbSet<Tra_Group> Tra_Groups { get; set; }
        public DbSet<Tra_Kind> Tra_Kinds { get; set; }
        public DbSet<Tra_Vehicle> Tra_Vehicles { get; set; }
        public DbSet<Tra_Detail> Tra_Details { get; set; }
    }
}