using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xMBSv2.Models.Entities
{
    using System.Data.Entity;
    using System.Web.Security;

    public class ZInitializer : DropCreateDatabaseAlways<ZContext>
    {
        protected override void Seed(ZContext context)
        {
            MembershipCreateStatus Status;
            Membership.CreateUser("Demo", "123456", "demo@demo.com", null, null, true, out Status);

            Roles.CreateRole("Admin");
            Roles.AddUserToRole("Demo", "Admin");
        }
    }
}