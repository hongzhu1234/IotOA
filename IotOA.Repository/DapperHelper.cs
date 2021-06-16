using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace IotOA.Repository
{
    public class DapperHelper<T>
    {
        public static object Salary(string sql)
        {
            using (IDbConnection conn = new SqlConnection("SQLConn"))
            {
                conn.Open();
                var result = conn.ExecuteScalar(sql);

                return result;
            }
        }
    }
}
