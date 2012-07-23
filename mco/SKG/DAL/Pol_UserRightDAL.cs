using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;
    using System.Data;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_UserRight
    /// </summary>
    public abstract class Pol_UserRightDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_UserRights.Count();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng Pol_UserRight cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var a = from s in _db.Pol_UserRights
                        select new
                        {
                            ID = s.Id,
                            ParentID = s.Pol_User.Id,
                            RightId = s.Pol_RightId,
                            Format = false,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Default,
                            s.Print,
                            s.Access,
                            s.Full,
                            s.None,

                            Name = s.Pol_Right.Caption,
                            Descript = s.Pol_Right.Descript,
                        };

                Guid? id = new Guid();

                var b = from s in _db.Pol_Users
                        select new
                        {
                            ID = s.Id,
                            ParentID = s.Id,
                            RightId = id,
                            Format = true,

                            Add = false,
                            Edit = false,
                            Delete = false,
                            Default = false,
                            Print = false,
                            Access = false,
                            Full = false,
                            None = false,

                            s.Name,
                            s.Descript
                        };

                var res = a.Union(b);

                if (obj != null)
                {
                    var o = (Pol_UserRight)obj;
                    res = res.Where(s => s.ID == o.Id);
                }

                if (take > 0) res = res.Skip(skip).Take(take);

                return res.OrderBy(s => s.Name).ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Pol_UserRight</param>
        /// <returns>Khác null: thêm thành công</returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_UserRight)obj;
                o.Id = Guid.NewGuid();

                var r = _db.Pol_Rights.
                    Where(s => s.Id == o.Pol_RightId)
                    .FirstOrDefault();
                o.Code = r.Code;
                o.Descript = r.Descript;

                var oki = _db.Pol_UserRights.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Pol_UserRight</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Pol_UserRight)obj;
                var res = _db.Pol_UserRights.SingleOrDefault(s => s.Id == o.Id);

                res.Add = o.Add;
                res.Edit = o.Edit;
                res.Delete = o.Delete;
                res.Default = o.Default;
                res.Print = o.Print;
                res.Access = o.Access;
                res.Full = o.Full;
                res.None = o.None;

                //res.Code = o.Code;
                //res.Descript = o.Descript;
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
                    var res = _db.Pol_UserRights.SingleOrDefault(s => s.Id == id);
                    _db.Pol_UserRights.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_UserRights.ToList();
                    tmp.ForEach(s => _db.Pol_UserRights.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}