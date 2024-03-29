﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 22:20
 * Update: 12/06/2013 12:38
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;

    /// <summary>
    /// Transport - Tra_Tariff processing
    /// </summary>
    public abstract class Tra_TariffDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Auto generate code
        /// </summary>
        /// <param name="format">Format code</param>
        /// <returns></returns>
        public string GenerateCode(string format)
        {
            try
            {
                var res = from s in _db.Tra_Tariffs
                          where s.Code.Contains(format)
                          && s.Show == true
                          orderby s.Code descending
                          select s;
                var tmp = res.FirstOrDefault().Code.Replace(format + "_", "");
                return String.Format("{0}_{1}", format, 1 + tmp.ToInt32());
            }
            catch
            {
                return String.Format("{0}_{1}", format, 0);
            }
        }

        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Tra_Tariffs.Count();
        }

        /// <summary>
        /// Tìm theo khoá ngoại
        /// </summary>
        /// <param name="fKey">Khoá ngoại</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(Guid fKey)
        {
            try
            {
                var res = from s in _db.Tra_Tariffs
                          where s.GroupId == fKey
                          orderby s.Order
                          select new
                          {
                              s.Id,

                              Region = "",
                              Area = s.Group.Text,
                              Route = s.Text,
                              s.Note,

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
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
                return _db.Tra_Tariffs.SingleOrDefault(s => s.Code == code);
            }
            catch { return null; }
        }

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Kind cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Tra_Tariffs

                          orderby s.Group.Text, s.Group.Order
                          select new
                          {
                              s.Id,
                              Tra_GroupId = s.GroupId,

                              Region = "",
                              Area = s.Group.Text,
                              Route = s.Text,
                              s.Note,

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                if (obj != null) res = res.Where(s => s.Code == obj + "");
                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Kind</param>
        /// <returns>Khác null: thêm thành công</returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Tra_Tariff)obj;
                if (o.Id == Guid.Empty) o.Id = Guid.NewGuid();

                var oki = _db.Tra_Tariffs.Add(o);
                _db.SaveChanges();

                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Kind</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Tra_Tariff)obj;
                var res = _db.Tra_Tariffs.SingleOrDefault(s => s.Id == o.Id);

                res.GroupId = o.GroupId;

                res.Text = o.Text;
                res.Price1 = o.Price1;
                res.Price2 = o.Price2;
                res.Rose1 = o.Rose1;
                res.Rose2 = o.Rose2;

                res.Code = o.Code;
                res.Note = o.Note;
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
                    var res = _db.Tra_Tariffs.SingleOrDefault(s => s.Id == id);
                    _db.Tra_Tariffs.Remove(res);
                }
                else
                {
                    var tmp = _db.Tra_Tariffs.ToList();
                    tmp.ForEach(s => _db.Tra_Tariffs.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion

        /// <summary>
        /// Bảng giá cho xe vãng lai
        /// </summary>
        /// <param name="skip">Bỏ qua mã này</param>
        /// <returns></returns>
        public DataTable SelectForNormal(string skip = null)
        {
            try
            {
                var res = from s in _db.Tra_Tariffs
                          where s.Group.Code.Contains("GROUP")
                          && s.Show == true
                          orderby s.Group.Text, s.Text
                          select new
                          {
                              s.Id,
                              Tra_GroupId = s.GroupId,

                              Group = s.Group.Text,
                              s.Text,
                              s.Note,

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                if (!skip.IsNullOrEmpty())
                    res = res.Where(p => !p.Code.Contains(skip));

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Bảng giá, hoa hồng cho xe cố định
        /// </summary>
        /// <returns></returns>
        public DataTable SelectForFixed()
        {
            try
            {
                var res = from s in _db.Tra_Tariffs
                          where s.Group.Code.Contains("PROVINCE")
                          && s.Show == true
                          orderby s.Group.Text, s.Text
                          select new
                          {
                              s.Id,
                              s.GroupId,

                              Area = s.Group.Text,
                              s.Text,
                              s.Note,

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
        }
    }
}