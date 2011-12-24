using System;
using System.Data;

namespace UTL.DAL
{
    public interface ItfDAL
    {
        /// <summary>
        /// Sum of all total records
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        DataTable GetData();

        /// <summary>
        /// Get all data limit
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        DataTable GetData(int skip, int take);

        /// <summary>
        /// Get all data limit by key
        /// </summary>
        /// <param name="key">primary key if pkey is true else foreign key</param>
        /// <param name="pkey"></param>
        /// <returns></returns>
        DataTable GetData(object key, bool pkey = true);

        /// <summary>
        /// Find a object by properties, not find by id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        DataTable Search(object obj);

        /// <summary>
        /// Get data by object
        /// </summary>
        /// <param name="obj">properties of object such as: id, ...</param>
        /// <returns>object found</returns>
        object GetData(object obj);

        /// <summary>
        /// Save object into database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Insert(object obj);

        /// <summary>
        /// Save object into database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Update(object id);

        /// <summary>
        /// Delete object from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(object id);

        /// <summary>
        /// Check object exists
        /// </summary>
        /// <param name="obj">properties of object such as: id, ...</param>
        /// <returns></returns>
        bool CheckExist(object obj);

        /// <summary>
        /// Get information (manulating on object return error or success & more
        /// </summary>
        /// <returns></returns>
        UTL.CsoInf GetInf();
    }
}