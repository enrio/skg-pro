using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Pol_User
    {
        public Guid Id { set; get; }

        public string Acc { set; get; }
        public string Pass { set; get; }
        public string Name { set; get; }
        public DateTime Birth { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public int Role { set; get; }
    }
}