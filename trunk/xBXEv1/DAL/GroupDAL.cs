﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using System.Data;

    /// <summary>
    /// DAL to Group table
    /// </summary>
    public abstract class GroupDAL : BaseDAL, IBase
    {
        /// <summary>
        /// Count all of records
        /// </summary>
        /// <returns>Number of records</returns>
        public int Count()
        {
            return _db.Groups.Count();
        }

        /// <summary>
        /// Select all data from table in database
        /// </summary>
        /// <returns>Data</returns>
        public DataTable Select()
        {
            try
            {
                var res = from s in _db.Groups
                          select new
                          {
                              s.Id,
                              s.Name
                          };
                return res.ToDataTable();
            }
            catch { return _dtb; }
        }


        /// <summary>
        /// Select data by object from table in database
        /// </summary>
        /// <param name="obj">Condition</param>
        /// <returns>Data</returns>
        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert object to table in database
        /// </summary>
        /// <param name="obj">Object need to insert</param>
        /// <returns>Enum's perform status of DAL</returns>
        public BaseDAL.State Insert(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update object to table in database
        /// </summary>
        /// <param name="obj">Object need to update</param>
        /// <returns>Enum's perform status of DAL</returns>
        public BaseDAL.State Update(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete object to table in database
        /// </summary>
        /// <param name="obj">Object need to delete</param>
        /// <returns>Enum's perform status of DAL</returns>
        public BaseDAL.State Delete(object obj)
        {
            throw new NotImplementedException();
        }
    }
}