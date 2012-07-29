#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 22:20
 * Update: 24/07/2012 22:48
 * Status: None
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using SKG.Extend;
    using System.Data;

    /// <summary>
    /// For test
    /// </summary>
    public static class Test
    {
        public static DataTable TestPivot()
        {
            // Sample data
            var data = new[] { new { Foo = 1, Bar = "Don Smith" }, 
                                 new { Foo = 1, Bar = "Mike Jones" }, 
                                 new { Foo = 1, Bar = "James Ray" }, 
                                 new { Foo = 2, Bar = "Tom Rizzo" }, 
                                 new { Foo = 2, Bar = "Alex Homes" }, 
                                 new { Foo = 3, Bar = "Andy Bates" } };
            // Group into columns, and select the rows per column
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

        public static DataTable TestPivot(ref DataTable src)
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

            // Before transpose
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
            return tr.ToDataTable();
        }
    }
}