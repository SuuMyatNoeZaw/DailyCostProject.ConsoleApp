using System;
using System.Collections.Generic;

namespace DailyCost.Database.Models;

public partial class TblDailyCost
{
    public int CostId { get; set; }

    public DateTime Date { get; set; }

    public string Thing { get; set; } = null!;

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public decimal TotalPrice { get; set; }

    public bool DeleteFlag { get; set; }
}
