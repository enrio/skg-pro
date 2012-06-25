using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DAL.Entities
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class ZContext
    {
        public DbSet<Pol_UserRole> Pol_UserRoles { get; set; }
    }
}