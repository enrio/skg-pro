using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Detail
    {
        public Guid Id { set; get; }

        public DateTime DateIn { set; get; }
        public DateTime DateOut { set; get; }

        [ForeignKey("UserIn")]
        public Guid? UserInId { set; get; }
        public virtual Pol_User UserIn { get; set; }

        [ForeignKey("UserOut")]
        public Guid? UserOutId { set; get; }
        public virtual Pol_User UserOut { get; set; }

        [ForeignKey("Vehicle")]
        public Guid? VehicleId { set; get; }
        public virtual Vehicle Vehicle { get; set; }
    }
}