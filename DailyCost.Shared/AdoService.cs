using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace DailyCost.Shared
{
    public class AdoService
    {
        string _connectionString;
       public AdoService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataTable Query(string query,params Parameters[] parameters)
        {
            SqlConnection connection= new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            foreach (Parameters param in parameters) 
            {
                cmd.Parameters.AddWithValue(param.Name,param.Value);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public int Execute(string query,params Parameters[] parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            foreach (Parameters param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Name, param.Value);
            }
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
          
        }
    }
    public class Parameters
    {
        public string Name {  get; set; }
        public object Value {  get; set; }
        public Parameters(string name,object value)
        {
            Name=name;
            Value=value;
        }
    }
}