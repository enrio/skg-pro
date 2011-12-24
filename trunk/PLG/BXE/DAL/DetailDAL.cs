using System;
using System.Linq;
using System.Data;
using System.Timers;

namespace BXE.DAL
{
    public class DetailDAL : CsoDAL, UTL.DAL.ItfDAL
    {
        #region Implement method
        public int Count()
        {
            return _mdb.Details.Count();
        }

        public DataTable GetData()
        {
            try
            {
                var res = from s in _mdb.Details

                          join v in _mdb.Vehicles on s.Number equals v.Number
                          join k in _mdb.Kinds on v.KindId equals k.Id

                          orderby s.Number

                          select new
                          {
                              Stt = "",

                              s.Id,
                              AccIn = s.User.Name,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut,
                              s.Day,
                              s.Hour,
                              s.Money,

                              v.Chair,
                              v.Weight,

                              k.Name,
                              k.Group,
                              k.Money1,
                              k.Money2,
                              k.Type
                          };
                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataTable GetData(int skip, int take)
        {
            try
            {
                var res = from s in _mdb.Details

                          join v in _mdb.Vehicles on s.Number equals v.Number
                          join k in _mdb.Kinds on v.KindId equals k.Id

                          orderby s.Number

                          select new
                          {
                              Stt = "",

                              s.Id,
                              AccIn = s.User.Name,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut,
                              s.Day,
                              s.Hour,
                              s.Money,

                              v.Chair,
                              v.Weight,

                              k.Name,
                              k.Group,
                              k.Money1,
                              k.Money2,
                              k.Type
                          };
                return UTL.DAL.MorUkxYlm.ToDataTable(res.Skip(skip).Take(take));
            }
            catch { return null; }
        }

        public DataTable GetData(object key, bool pkey = true)
        {
            long id;

            if (pkey) { id = ((Detail)key).Id; }
            else { return null; }

            try
            {
                var res = from s in _mdb.Details
                          where s.Id == id
                          orderby s.Number
                          select new
                          {
                              s.Id,
                              AccIn = s.User.Name,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut
                          };
                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataTable Search(object obj)
        {
            Detail o = (Detail)obj;

            try
            {
                var res = from s in _mdb.Details

                          join v in _mdb.Vehicles on s.Number equals v.Number
                          join k in _mdb.Kinds on v.KindId equals k.Id

                          where s.Number == o.Number
                          orderby s.Number

                          select new
                          {
                              s.Id,
                              AccIn = s.User.Name,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut,
                              s.Day,
                              s.Hour,
                              s.Money,

                              v.Chair,
                              v.Weight,
                              v.Length,

                              KindId = k.Id,
                              KindName = k.Name,
                              GroupId = k.Group.Id,
                              GroupName = k.Group.Name,

                              k.Money1,
                              k.Money2,
                              k.Type
                          };

                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public object GetData(object obj)
        {
            string number = ((DAL.Detail)obj).Number;

            try
            {
                var res = from s in _mdb.Details
                          where s.Number == number && s.AccOut == null
                          orderby s.Number
                          select new
                          {
                              s.Id,
                              AccIn = s.User.Name,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut,
                              s.Money,
                              s.Price1,
                              s.Price2
                          };
                return res.Single();
            }
            catch { return null; }
        }

        public bool Insert(object obj)
        {
            Detail o = (Detail)obj;

            try
            {
                _mdb.Details.Single(k => k.Number == o.Number && k.DateOut == null);

                return false;
            }
            catch
            {
                o.DateIn = o.DateIn;
                _mdb.Details.InsertOnSubmit(o);
                _mdb.SubmitChanges();

                return true;
            }
        }

        public bool Update(object obj)
        {
            Detail o = (Detail)obj;

            try
            {
                var res = _mdb.Details.Single(k => k.Number == o.Number && k.DateOut == null);
                res.AccOut = o.AccOut;
                res.DateOut = o.DateOut;

                _mdb.SubmitChanges();

                return true;
            }
            catch { return false; }
        }

        public bool Delete(object obj)
        {
            long id = ((Detail)obj).Id;

            try
            {
                var res = from s in _mdb.Details
                          where s.Id == id
                          select s;
                if (res != null)
                {
                    var et = res.Single();
                    _mdb.Details.DeleteOnSubmit(et);
                    _mdb.SubmitChanges();

                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckExist(object obj)
        {
            return false;
        }

        public UTL.CsoInf GetInf()
        {
            return null;
        }
        #endregion

        public DataTable ThongKe()
        {
            try
            {
                var res = from s in _mdb.Details
                          where s.DateOut != null && !_mdb.Details.Any(p => p.Number == s.Number && p.DateOut == null)
                          && s.DateOut == (from y in _mdb.Details where y.Number == s.Number select (DateTime?)y.DateOut).Max()
                          orderby s.Number
                          group s by new { AccOut = s.User1.Name } into newInfo
                          select new
                          {
                              AccOut = newInfo.Key.AccOut,
                              Money = newInfo.Sum(o => o.Money)
                          };
                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataTable GetListIn(out decimal total, bool staIn = true)
        {
            total = 0;

            try
            {
                if (staIn)
                {
                    var res = from s in _mdb.Details

                              join v in _mdb.Vehicles on s.Number equals v.Number
                              join k in _mdb.Kinds on v.KindId equals k.Id

                              where s.AccOut == null
                              orderby s.Number

                              select new
                              {
                                  s.Id,
                                  AccIn = s.User.Name,
                                  Phone = s.User.Phone,
                                  s.Number,
                                  s.DateIn,

                                  v.Chair,
                                  v.Weight,
                                  v.Length,

                                  KindName = k.Name,
                                  GroupName = k.Group.Name,
                              };

                    total = res.Count();
                    return UTL.DAL.MorUkxYlm.ToDataTable(res);
                }
                else
                {
                    var res = from s in _mdb.Details
                              where s.DateOut != null && !_mdb.Details.Any(p => p.Number == s.Number && p.DateOut == null)
                              && s.DateOut == (from y in _mdb.Details where y.Number == s.Number select (DateTime?)y.DateOut).Max()
                              orderby s.AccOut, s.Number
                              select new
                              {
                                  AccIn = s.User.Name,
                                  AccOut = s.User1.Name,
                                  s.Number,
                                  s.DateIn,
                                  s.DateOut,
                                  s.Day,
                                  s.Hour,

                                  s.Price1,
                                  s.Price2,
                                  s.Money
                              };

                    total = res.Sum(k => k.Money).Value;
                    return UTL.DAL.MorUkxYlm.ToDataTable(res);
                }
            }
            catch { return null; }
        }

        public DataTable InvoiceOut(Detail obj, ref int day, ref int hour, ref decimal money, ref decimal price1, ref decimal price2, bool isOut = false)
        {
            try
            {
                // Cập nhật thông tin xe ra
                var d = _mdb.Details.Single(k => k.Number == obj.Number && k.AccOut == null);

                d.AccOut = obj.AccOut; // Id user đang đăng nhập
                d.DateOut = obj.DateOut; // thời gian hiện tại trên server

                TimeSpan? dt = d.DateOut - d.DateIn; // tính số giờ đậu tại bến                
                hour = dt.Value.Hours;
                day = dt.Value.Days;
                d.Day = day;
                d.Hour = hour;

                var res = from s in _mdb.Details

                          join v in _mdb.Vehicles on s.Number equals v.Number
                          join k in _mdb.Kinds on v.KindId equals k.Id

                          where s.Number == obj.Number
                          orderby s.Number

                          select new
                          {
                              s.Id,
                              AccIn = s.User.Name,
                              Phone = s.User.Phone,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut,
                              s.Day,
                              s.Hour,
                              s.Money,

                              v.Chair,
                              v.Weight,

                              k.Name,
                              k.GroupId,
                              GroupName = k.Group.Name,
                              k.Money1,
                              k.Money2,
                              k.Type
                          };

                var ok = res.Single(h => h.DateOut == null);

                int dayL = (hour > 0 && hour < 12) ? 1 : 0;
                int dayF = (hour >= 12) ? day + 1 : day;

                price1 = ok.Money1 != null ? ok.Money1.Value : 0;
                price2 = ok.Money2 != null ? ok.Money2.Value : 0;

                int chair = ok.Chair != null ? ok.Chair.Value : 0;

                money = 0;

                switch (ok.GroupId.Value)
                {
                    case 1:
                        if (dayF == 0) money = price1;
                        else money = dayF * price2 + dayL * price1;
                        break;

                    case 2:
                        price1 = price2 / 2;
                        if (dayF == 0) money = price2;
                        else money = dayF * price2 + dayL * price1;
                        break;

                    case 3:
                        money = price2;
                        break;

                    case 4:
                        money = price2;
                        break;

                    case 5:
                        if (day == 0) money = price2 * chair;
                        else money = (day * 60 + hour) * price2 * chair;
                        break;

                    default:

                        break;
                }

                d.Money = money;
                d.Price1 = price1;
                d.Price2 = price2;

                if (isOut) _mdb.SubmitChanges();

                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataSet GetDataSetInMinute()
        {
            var oki = new DataSet();
            oki.Tables.Add(GetDataInMinute());
            return oki;
        }

        public DataTable GetDataInMinute()
        {
            try
            {
                var res = from s in _mdb.Details

                          join k in _mdb.Vehicles on s.Number equals k.Number
                          where s.DateOut == null && s.DateIn.Value.AddMinutes(1) >= _mdb.CurrentTime()

                          orderby s.DateIn
                          select new
                          {
                              s.Id,
                              s.Number,
                              AccIn = s.User.Name,
                              Phone = s.User.Phone,
                              s.DateIn,

                              GroupId = k.Kind.GroupId,
                              KindId = k.KindId,
                              GroupName = k.Kind.Group.Name,
                              KindName = k.Kind.Name,
                              k.Length,
                              k.Weight,
                              k.Chair
                          };

                return UTL.DAL.MorUkxYlm.ToDataTable(res);

            }
            catch { return null; }
        }

        public DataSet InvoiceOutDataSet(Detail obj, ref int day, ref int hour, ref decimal money, ref decimal price1, ref decimal price2, bool isOut = false)
        {
            var oks = new DataSet();
            oks.Tables.Add(InvoiceOut(obj, ref  day, ref  hour, ref  money, ref  price1, ref  price2, isOut));
            return oks;
        }

        public bool UpdateNumber(string number, Vehicle obj)
        {
            try
            {
                var res = _mdb.Details.Single(k => k.Number == number && k.DateOut == null);
                res.Number = obj.Number;

                var res1 = _mdb.Vehicles.Single(k => k.Number == number);
                res1.Number = obj.Number;
                res1.KindId = obj.KindId;
                res1.Chair = obj.Chair;
                res1.Weight = obj.Weight;

                _mdb.SubmitChanges();

                return true;
            }
            catch { return false; }
        }

        public DataTable GetInList(bool isInList = true)
        {
            return isInList ? UTL.DAL.MorUkxYlm.ToDataTable(_mdb.Details_In()) : UTL.DAL.MorUkxYlm.ToDataTable(_mdb.Details_Out());
        }

        /// <summary>
        /// Delete by number & this vehicle in station (AccAout is null)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool DeleteByNumber(string number)
        {
            try
            {
                var res = from s in _mdb.Details
                          where s.Number == number && s.AccOut == null
                          select s;
                if (res != null)
                {
                    var et = res.Single();
                    _mdb.Details.DeleteOnSubmit(et);
                    _mdb.SubmitChanges();

                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public DataTable SumaryDateOut(out decimal total, DateTime fr, DateTime to)
        {
            total = 0;

            try
            {
                var res = from s in _mdb.Details
                          join k in _mdb.Vehicles on s.Number equals k.Number

                          where s.DateOut != null && !_mdb.Details.Any(p => p.Number == s.Number && p.DateOut == null)
                          && s.DateOut == (from y in _mdb.Details where y.Number == s.Number select (DateTime?)y.DateOut).Max()
                          && s.DateOut >= fr && s.DateOut <= to

                          orderby s.AccOut, s.Number
                          select new
                          {
                              AccIn = s.User.Name,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut,
                              s.Day,
                              s.Hour,
                              s.Price1,
                              s.Price2,
                              s.Money,

                              KindName = k.Kind.Name,
                              GroupName = k.Kind.Group.Name,
                              k.Length,
                              k.Weight,
                              k.Chair
                          };

                total = res.Sum(k => k.Money).Value;
                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataTable SumaryDateIn(out decimal total, DateTime fr, DateTime to)
        {
            total = 0;

            try
            {
                var res = from s in _mdb.Details
                          join k in _mdb.Vehicles on s.Number equals k.Number

                          where s.DateOut != null && !_mdb.Details.Any(p => p.Number == s.Number && p.DateOut == null)
                          && s.DateOut == (from y in _mdb.Details where y.Number == s.Number select (DateTime?)y.DateOut).Max()
                          && s.DateIn >= fr && s.DateIn <= to

                          orderby s.AccOut, s.Number
                          select new
                          {
                              AccIn = s.User.Name,
                              AccOut = s.User1.Name,
                              s.Number,
                              s.DateIn,
                              s.DateOut,
                              s.Day,
                              s.Hour,
                              s.Price1,
                              s.Price2,
                              s.Money,

                              KindName = k.Kind.Name,
                              GroupName = k.Kind.Group.Name,
                              k.Length,
                              k.Weight,
                              k.Chair
                          };

                total = res.Sum(k => k.Money).Value;
                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }
    }
}