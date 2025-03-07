using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Table("Tbl_DailyCost")]
    public class DailyCostEFCoreModel
    {
        [Key]
        [Column("CostID")]
        public int CostId { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("Thing")]
        public string Thing { get; set; }
        [Column("Qty")]
        public int Qty { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [Column("TotalPrice")]
        public decimal TotalPrice { get; set; }
        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }




    }
}
