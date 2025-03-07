using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCost.ConsoleApp
{
    public class DailyCostEFCore
    {
        AppDbContext _db=new AppDbContext();
        public void Read()
        {
            var list=_db.DailyCosts.ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.CostId);
                Console.WriteLine(item.Date);
                Console.WriteLine(item.Thing);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Qty);
                Console.WriteLine(item.TotalPrice);
                Console.WriteLine(item.DeleteFlag);
            }

        }
    }
}
