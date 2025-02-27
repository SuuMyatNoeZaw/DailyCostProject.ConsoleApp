using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCost.Shared
{
    public class DapperService
    {
        public string _connectionString;
       public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<T> Query<T>(string query,object param=null)
        {
            using IDbConnection db=new SqlConnection( _connectionString );
           var list= db.Query<T>(query,param).ToList();
            return list;
        }
        public T QueryFOD<T>(string query, object param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var list = db.Query<T>(query, param).FirstOrDefault();
            return list;
        }
        public int Execute(string query, object param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            int result = db.Execute(query, param);
            return result;
        }

    }
}
