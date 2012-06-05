using System;

namespace UTL.DAL
{
    public class CsoDAL
    {
        #region Constants
        public const string STR_BACKUP = @"BACKUP DATABASE {0} " +
            @"TO DISK = N'{1}' WITH NOFORMAT, NOINIT, " +
            @"NAME = N'{2}', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

        public const string STR_RESTOR = @"USE MASTER; DROP DATABASE {0}; RESTORE DATABASE {0} " +
            @"FROM  DISK = N'{1}' WITH  FILE = 1, NOUNLOAD, STATS = 10";

        public const string STR_CREATE = @"CREATE DATABASE {0} " +
            @"ON  PRIMARY (NAME = N'{0}', FILENAME = N'{1}\{0}.mdf', SIZE = 3072KB, FILEGROWTH = 1024KB) " +
            @"LOG ON (NAME = N'{0}_log', FILENAME = N'{1}\{0}_log.ldf', SIZE = 1024KB, FILEGROWTH = 10%) " +
            @"COLLATE VIETNAMESE_CI_AI";

        public const string STR_DBNAME = "master";
        #endregion

        public static string FileDb { set; get; }
        public static string DbName { set; get; }
    }
}