using System;

namespace UTL.BLL
{
    public sealed class UecLajVei
    {
        public enum Roles { Admin, Manager, User, Gatein, Gateout, None };

        private bool _login;

        public long Id { set; get; }
        public string Acc { set; get; }
        public string Pass { set; get; }
        public string Name { set; get; }
        public Roles Role { set; get; }
        public DateTime? Current { set; get; }

        public bool Login
        {
            set
            {
                if (value == false)
                {
                    Id = -1;
                    Acc = null;
                    Pass = null;
                    Name = "USER";
                    Role = Roles.None;
                }
                _login = value;
            }
            get
            {
                return _login;
            }
        }

        public UecLajVei()
        {
            Login = false;
        }
    }
}