using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DailyCost.ConsoleApp
{
    public class DailyCostAdo
    {
        string _connectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS; Initial Catalog=F9DB;Trusted_Connection=True;";

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "Select * from Tbl_DailyCost";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["CostID"]);
                Console.WriteLine(dr["Date"]);
                Console.WriteLine(dr["Thing"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine(dr["TotalPrice"]);
                Console.WriteLine(dr["DeleteFlag"]);
            }
        }
        public void Edit()
        {
            Console.WriteLine("Enter Cost ID");
            int id = Int32.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $"Select * from Tbl_DailyCost where CostID=@CostID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CostId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            var dr = dt.Rows[0];
            Console.WriteLine(dr["CostID"]);
            Console.WriteLine(dr["Date"]);
            Console.WriteLine(dr["Thing"]);
            Console.WriteLine(dr["Qty"]);
            Console.WriteLine(dr["Price"]);
            Console.WriteLine(dr["TotalPrice"]);

        }
        public void Create()
        {
            Console.WriteLine("Enter Thing");
            string thing=Console.ReadLine();
            Console.WriteLine("Enter Quantity");
            int qty=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price");
            decimal price=Decimal.Parse(Console.ReadLine());
            DateTime date = DateTime.Now;
            decimal totalprice = price*qty;
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"INSERT INTO [dbo].[Tbl_DailyCost]
           ([Date]
           ,[Thing]
           ,[Qty]
           ,[Price]
           ,[TotalPrice]
           ,[DeleteFlag])
     VALUES
           (@Date
           ,@Thing
           ,@Qty
           ,@Price
           ,@TotalPrice
           ,0)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Date",date);
            cmd.Parameters.AddWithValue("Thing", thing);
            cmd.Parameters.AddWithValue("Qty", qty);
            cmd.Parameters.AddWithValue("Price", price);
            cmd.Parameters.AddWithValue("TotalPrice", totalprice);
            int result=cmd.ExecuteNonQuery();
            connection.Close() ;
            Console.WriteLine(result==1?"Your Task is Succeed.":"Your Task is Failed.");
        }
        public void Update()
        {
            Console.WriteLine("Enter ID");
            int id= Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Thing");
            string thing = Console.ReadLine();
            Console.WriteLine("Enter Quantity");
            int qty = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price");
            decimal price = Decimal.Parse(Console.ReadLine());
            
            DateTime date = DateTime.Now;
            decimal totalprice = price * qty;
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"UPDATE [dbo].[Tbl_DailyCost]
   SET [Date] = @Date
      ,[Thing] = @Thing
      ,[Qty] = @Qty
      ,[Price] =@Price
      ,[TotalPrice] = @TotalPrice
      ,[DeleteFlag] = 0
 WHERE CostID=@CostID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CostID", id);
            cmd.Parameters.AddWithValue("Date", date);
            cmd.Parameters.AddWithValue("Thing", thing);
            cmd.Parameters.AddWithValue("Qty", qty);
            cmd.Parameters.AddWithValue("Price", price);
            cmd.Parameters.AddWithValue("TotalPrice", totalprice);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result == 1 ? "Your Task is Succeed." : "Your Task is Failed.");
        }
        public void Delete()
        {
            Console.WriteLine("Enter Cost ID");
            int id= Int32.Parse(Console.ReadLine());
            
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
                            string query = $@"UPDATE [dbo].[Tbl_DailyCost]
                   SET [DeleteFlag] = 1
                 WHERE CostID=@CostID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CostID", id);
            int result=cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result==1?"Your Task is succeed.":"Your Task is Failed.");
        }
    }
}
