using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using Entities;
    using System.Data;
    using System.Data.Entity;

    /// <summary>
    /// Base abstract class Data Access Layer
    /// </summary>
    public abstract class BaseDAL
    {
        protected Context _db = new Context();
        protected DataTable _tb = new DataTable("Tmp");

        public BaseDAL()
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DataTable TestPivot()
        {
            // sample data
            var data = new[] { new { Foo = 1, Bar = "Don Smith" }, 
                                 new { Foo = 1, Bar = "Mike Jones" }, 
                                 new { Foo = 1, Bar = "James Ray" }, 
                                 new { Foo = 2, Bar = "Tom Rizzo" }, 
                                 new { Foo = 2, Bar = "Alex Homes" }, 
                                 new { Foo = 3, Bar = "Andy Bates" }, };

            // group into columns, and select the rows per column
            var grps = from d in data
                       group d by d.Foo
                           into grp
                           select new
                           {
                               Foo = grp.Key,
                               Bars = grp.Select(d2 => d2.Bar).ToArray()
                           };

            return grps.ToDataTable();
        }

        public class Sales
        {
            public int Sequence { get; set; }
            public int Sequence2 { get; set; }
            public string Day { get; set; }
            public double Amount { get; set; }
        }

        public DataTable TestPivot(ref DataTable src)
        {
            var week_days = new List<Sales>();
            week_days.Add(new Sales { Sequence = 1, Sequence2 = 8, Day = "Sun", Amount = 23 });
            week_days.Add(new Sales { Sequence = 2, Sequence2 = 8, Day = "Mon", Amount = 18 });
            week_days.Add(new Sales { Sequence = 3, Sequence2 = 8, Day = "Tue", Amount = 30 });
            week_days.Add(new Sales { Sequence = 4, Sequence2 = 8, Day = "Wed", Amount = 15 });
            week_days.Add(new Sales { Sequence = 5, Sequence2 = 8, Day = "Thu", Amount = 20 });
            week_days.Add(new Sales { Sequence = 6, Sequence2 = 8, Day = "Fri", Amount = 08 });
            week_days.Add(new Sales { Sequence = 7, Sequence2 = 8, Day = "Sat", Amount = 0 });
            week_days.Add(new Sales { Sequence = 8, Sequence2 = 0, Day = "Fri", Amount = 18 });

            src = week_days.ToDataTable();

            //Before transpose
            foreach (var day in week_days)
                Console.WriteLine("{0}  {1}  {2}", day.Sequence, day.Day, day.Amount);

            var tr = from row in week_days
                     group row by "SALES" into g
                     where g.FirstOrDefault() != null
                     select new
                     {
                         DAY = g.Key,
                         Sun = g.Where(sales => sales.Day == "Sun").Sum(sales => sales.Amount),
                         Mon = g.Where(sales => sales.Day == "Mon").Sum(sales => sales.Amount),
                         Tue = g.Where(sales => sales.Day == "Tue").Sum(sales => sales.Amount),
                         Wed = g.Where(sales => sales.Day == "Wed").Sum(sales => sales.Amount),
                         Thu = g.Where(sales => sales.Day == "Thu").Sum(sales => sales.Amount),
                         Fri = g.Where(sales => sales.Day == "Fri").Sum(sales => sales.Amount),
                         Sat = g.Where(sales => sales.Day == "Sat").Sum(sales => sales.Amount)
                     };

            /*foreach (var day in tr)
                Console.Write("{0} {1} {2} {3} {4} {5} {6}", day.Sun, day.Mon, day.Tue, day.Wed, day.Thu, day.Fri, day.Sat);

            Console.ReadLine();*/

            return tr.ToDataTable();
        }

        public DataTable TestUnion()
        {
            try
            {
                var a = from s in _db.Pol_RoleRights
                        select new
                        {
                            s.Pol_RoleId,
                            s.Pol_RightId,
                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Full,
                            s.None,
                            Code = s.Pol_Right.Code,
                            RoleName = s.Pol_Role.Name,
                            RoleDescript = s.Pol_Role.Descript,
                            RightName = s.Pol_Right.Name,
                            RightDescript = s.Pol_Right.Descript
                        };


                Guid? id = Guid.NewGuid();

                var b = from s in _db.Pol_Rights
                        select new
                        {
                            //Pol_RoleId = s.Id,
                            Pol_RoleId = id,
                            Pol_RightId = id,
                            Add = false,
                            Edit = false,
                            Delete = false,
                            Query = false,
                            Print = false,
                            Full = false,
                            None = false,
                            s.Code,
                            RoleName = "",
                            RoleDescript = "",
                            RightName = s.Name,
                            RightDescript = s.Descript
                        };

                var infoQuery = (from cust in _db.Pol_Roles select cust.Code).Union(from emp in _db.Pol_Rights select emp.Name);

                var x = from s in _db.Pol_Rights
                        select new { s.Id, s.Code };
                var y = from s in _db.Pol_Roles
                        select new { s.Id, s.Code };

                var w = x.Union(y);
                var z = a.Union(b);

                return z.ToDataTable();
            }
            catch { return _tb; }
        }
    }
}