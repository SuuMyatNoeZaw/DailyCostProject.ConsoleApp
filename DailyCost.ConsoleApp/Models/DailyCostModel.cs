using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCost.ConsoleApp.Models
{
    public class DailyCostModel
    {
        public int CostId { get; set; }
        public DateTime Date { get; set; }

        public string Thing { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public bool DeleteFlag { get; set; }

       


    }
}
