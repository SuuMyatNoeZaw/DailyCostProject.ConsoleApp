using DailyCost.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DailyCost.ConsoleApp
{
    public class DailyAdoService
    {
        private readonly string ConnectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS; Initial Catalog=F9DB;Trusted_Connection=True;";
        private readonly AdoService adoService;
       public DailyAdoService()
        {
            adoService = new AdoService(ConnectionString);
        }
        public void Read()
        {
            string query = "Select * from Tbl_DailyCost";
           var  dt=adoService.Query(query);
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
        public void Edit(int id)
        {
            string query = $"Select * from Tbl_DailyCost where CostID=@CostId";
            var dt = adoService.Query(query,new Parameters("@CostId",id));
          var dr = dt.Rows[0];
                Console.WriteLine(dr["CostID"]);
                Console.WriteLine(dr["Date"]);
                Console.WriteLine(dr["Thing"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine(dr["TotalPrice"]);
                Console.WriteLine(dr["DeleteFlag"]);
           
        }
        public void Create(string thing,int qty,decimal price) 
        {
            decimal totalprice = price * qty;
            DateTime date= DateTime.Now;
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
           ,0";
            int result = adoService.Execute(query, new Parameters("@Date", date),
                new Parameters("@Thing", thing),
                new Parameters("@Qty", qty),
                new Parameters("@Price", price),
                new Parameters("@TotalPrice", totalprice));
            Console.WriteLine(result==1?"Your Task is succeed.": "Your Task is Failed.");
                
        }
        public void Delete(int id) 
        {
            Console.WriteLine("Enter Cost ID");
             id = Int32.Parse(Console.ReadLine());
            string query = $@"UPDATE [dbo].[Tbl_DailyCost]
                   SET [DeleteFlag] = 1
                 WHERE CostID=@CostID";
            int result=adoService.Execute(query,new Parameters("@CostID",id)
                );
            Console.WriteLine(result == 1 ? "Your Task is succeed." : "Your Task is Failed.");
        }

    }
}
