using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public abstract class GroupDAL : BaseDAL
    {
        public List<DAL.Entities.Group> GetAll()
        {
            var allFoods = from p in _db.Groups
                           orderby p.Name
                           select p;


            return allFoods.ToList();
        }

        public System.Data.DataTable GetAlls()
        {
            var allFoods = from p in _db.Groups
                           orderby p.Name
                           select p;


            return ConvertListToDataTable(allFoods.ToList());
        }
    }

}