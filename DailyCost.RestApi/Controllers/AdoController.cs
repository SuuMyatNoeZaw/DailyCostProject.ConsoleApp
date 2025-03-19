using DailyCost.Database.Models;
using DailyCost.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DailyCost.RestApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdoController : ControllerBase
    {
        private readonly string connectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS;Initial Catalog=F9DB;Trusted_Connection=True;TrustServerCertificate=True;";
        [HttpGet]
        public IActionResult Get()
        {
            List<TblDailyCost> list = new List<TblDailyCost>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select * from Tbl_DailyCost";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["CostID"]);
                Console.WriteLine(reader["Date"]);
                Console.WriteLine(reader["Thing"]);
                Console.WriteLine(reader["Qty"]);
                Console.WriteLine(reader["Price"]);
                Console.WriteLine(reader["TotalPrice"]);
                Console.WriteLine(reader["DeleteFlag"]);
                list.Add(new TblDailyCost
                {
                    CostId = Convert.ToInt32((reader["CostID"])),
                    Date = Convert.ToDateTime(reader["Date"]),
                    Thing = Convert.ToString(reader["Thing"]),
                    Qty = Convert.ToInt32((reader["Qty"])),
                    Price = Convert.ToDecimal(reader["Price"]),
                    TotalPrice = Convert.ToDecimal(reader["TotalPrice"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                });
            }
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            TblDailyCost item = new TblDailyCost();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select * from Tbl_DailyCost where CostID=@CostId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CostId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                item.CostId = Convert.ToInt32((reader["CostID"]));
                item.Date = Convert.ToDateTime(reader["Date"]);
                item.Thing = Convert.ToString(reader["Thing"]);
                item.Qty = Convert.ToInt32((reader["Qty"]));
                item.Price = Convert.ToDecimal(reader["Price"]);
                item.TotalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                item.DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"]);

            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(ViewModel cost)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            DateTime date = DateTime.Now;
            Decimal totalprice = cost.Price * cost.Qty;
            string query = @"INSERT INTO [dbo].[Tbl_DailyCost]
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
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Thing", cost.Thing);
            cmd.Parameters.AddWithValue("@Qty", cost.Qty);
            cmd.Parameters.AddWithValue("@Price", cost.Price);
            cmd.Parameters.AddWithValue("@TotalPrice", totalprice);
            int result = cmd.ExecuteNonQuery();

            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ViewModel cost)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            DateTime date = DateTime.Now;
            Decimal totalprice = cost.Price * cost.Qty;
            string query = @"UPDATE [dbo].[Tbl_DailyCost]
   SET [Date] = @Date
      ,[Thing] = @Thing
      ,[Qty] = @Qty
      ,[Price] = @Price
      ,[TotalPrice] = @TotalPrice
      ,[DeleteFlag] = 0
 WHERE CostID=@CostId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CostId", id);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Thing", cost.Thing);
            cmd.Parameters.AddWithValue("@Qty", cost.Qty);
            cmd.Parameters.AddWithValue("@Price", cost.Price);
            cmd.Parameters.AddWithValue("@TotalPrice", totalprice);
            int result = cmd.ExecuteNonQuery();

            return Ok(result);
        }
        [HttpDelete("{id}")]
       
        public IActionResult Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            DateTime date = DateTime.Now;
            string query = @"UPDATE [dbo].[Tbl_DailyCost]
   SET [Date] = @Date
     
      ,[DeleteFlag] = 1
 WHERE CostID=@CostId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CostId", id);
            cmd.Parameters.AddWithValue("@Date", date);
            int result = cmd.ExecuteNonQuery();

            return Ok(result);
        }
       

    }
}


