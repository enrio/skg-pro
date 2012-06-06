using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_User
    /// </summary>
    public abstract class Pol_UserDAL : BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_Users.Count();
        }

        /// <summary>
        /// Tìm theo khoá ngoại
        /// </summary>
        /// <param name="fKey">Khoá ngoại</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(Guid fKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tìm theo mã (cột Code)
        /// </summary>
        /// <param name="code">Mã cần tìm</param>
        /// <returns>Đối tượng tìm</returns>
        public object Select(string code)
        {
            try
            {
                return _db.Pol_Users.SingleOrDefault(s => s.Acc == code);
            }
            catch { return null; }
        }

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng Pol_User cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Pol_Users
                          select new
                          {
                              s.Id,
                              s.Acc,
                              s.Pass,
                              s.Name,
                              s.Birth,
                              s.Address,
                              s.Phone
                          };

                if (obj != null) res = res.Where(s => s.Acc == obj + "");
                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Pol_User</param>
        /// <returns>Khác null: thêm thành công</returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_User)obj;

                if (Select(o.Acc) != null) return null; // tài khoản này có rồi

                o.Id = Guid.NewGuid();
                o.Pass = UTL.Hasher.Code.Encode(o.Pass);
                var oki = _db.Pol_Users.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Pol_User</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Pol_User)obj;
                var res = _db.Pol_Users.SingleOrDefault(s => s.Id == o.Id || s.Acc == o.Acc);

                res.Pass = o.Pass;
                res.Name = o.Name;
                res.Birth = o.Birth;
                res.Address = o.Address;
                res.Phone = o.Phone;

                res.Code = o.Code;
                res.Descript = o.Descript;
                res.Order = o.Order;
                res.Show = o.Show;

                return _db.SaveChanges();
            }
            catch { return null; }
        }

        /// <summary>
        /// Xoá dữ liệu, không nhập khoá sẽ xoá tất cả
        /// </summary>
        /// <param name="id">Khoá chính</param>
        /// <returns>Khác null: xoá thành công</returns>
        public object Delete(Guid id = new Guid())
        {
            try
            {
                if (id != new Guid())
                {
                    var res = _db.Pol_Users.SingleOrDefault(s => s.Id == id);
                    _db.Pol_Users.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_Users.ToList();
                    tmp.ForEach(s => _db.Pol_Users.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion

        /// <summary>
        /// Lấy tất cả các quyền (chức năng) của người dùng
        /// </summary>
        /// <param name="userId">Id người dùng đăng nhập</param>
        /// <returns>Danh sách các quyền (chức năng)</returns>
        public List<ZAction> GetRights(Guid userId)
        {
            try
            {
                var a = from s in _db.Pol_UserRights

                        join u in _db.Pol_Users on s.Pol_UserId equals u.Id
                        join r in _db.Pol_Rights on s.Pol_RightId equals r.Id

                        where s.Pol_UserId == userId
                        select new
                        {
                            RightCode = r.Code,
                            RightName = r.Name,
                            RightDescript = r.Descript,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Access,
                            s.Default,
                            s.Full,
                            s.None
                        };

                var b = from s in _db.Pol_RoleRights

                        join r in _db.Pol_Rights on s.Pol_RightId equals r.Id
                        join ur in _db.Pol_UserRoles on s.Pol_RoleId equals ur.Pol_RoleId
                        join u in _db.Pol_Users on ur.Pol_UserId equals u.Id

                        where ur.Pol_User.Id == userId
                        select new
                        {
                            RightCode = r.Code,
                            RightName = r.Name,
                            RightDescript = r.Descript,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Access,
                            s.Default,
                            s.Full,
                            s.None
                        };

                var tmp = a.Union(b);

                var lst = new List<ZAction>();

                foreach (var res in tmp)
                {
                    var z = new ZAction()
                    {
                        Code = res.RightCode,
                        Add = res.Add,
                        Edit = res.Edit,
                        Delete = res.Delete,
                        Query = res.Query,
                        Print = res.Print,
                        Access = res.Access,
                        Default = res.Default,
                        Full = res.Full,
                        None = res.None
                    };

                    lst.Add(z);
                }

                return lst;
            }
            catch { return null; }
        }
    }
}