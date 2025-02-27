using DailyCost.ConsoleApp.Models;
using DailyCost.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCost.ConsoleApp
{
    public class DailyDapperService
    {
        private readonly string ConnectionString= "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS; Initial Catalog=F9DB;Trusted_Connection=True;";
        private readonly DapperService _dapperService;
        public DailyDapperService()
        {
            _dapperService = new DapperService(ConnectionString);
        }

        public void Read()
        {
            string query = "Select * from Tbl_DailyCost";
            var list = _dapperService.Query<DailyCostModel>(query);
            foreach (var item in list)
            {
                Console.WriteLine(item.CostId);
                Console.WriteLine(item.Date);
                Console.WriteLine(item.Thing);
                Console.WriteLine(item.Qty);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.TotalPrice);
                Console.WriteLine(item.DeleteFlag);
            }
        }

    }
}
