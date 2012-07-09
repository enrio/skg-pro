using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.DAL.Entities
{
    using System.Data.Entity;

    public class ZContext : SKG.DAL.Entities.Context
    {
        public DbSet<Tra_Group> Tra_Groups { get; set; }
        public DbSet<Tra_Kind> Tra_Kinds { get; set; }
        public DbSet<Tra_Vehicle> Tra_Vehicles { get; set; }
        public DbSet<Tra_Detail> Tra_Details { get; set; }
    }
}