using DailyCost.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var dt = adoService.Query(query,new Parameters("CostId",id));
          var dr = dt.Rows[0];
                Console.WriteLine(dr["CostID"]);
                Console.WriteLine(dr["Date"]);
                Console.WriteLine(dr["Thing"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine(dr["TotalPrice"]);
                Console.WriteLine(dr["DeleteFlag"]);
           
        }

    }
}
