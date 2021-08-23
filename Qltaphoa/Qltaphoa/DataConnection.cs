using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Qltaphoa
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source = DESKTOP-CUNAA3I\\SQLEXPRESS; Initial Catalog=QLtaphoa; UID=sa; PWD=123;";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
