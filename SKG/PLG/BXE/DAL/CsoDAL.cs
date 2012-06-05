using System;

namespace BXE.DAL
{
    public class CsoDAL
    {
        protected BXEDataContext _mdb = new BXEDataContext();

        public DateTime? CurrentTime()
        {
            return _mdb.CurrentTime();
        }
    }
}