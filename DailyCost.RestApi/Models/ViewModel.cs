namespace DailyCost.RestApi.Models
{
    public class ViewModel
    {
        public int CostId { get; set; }

        

        public string Thing { get; set; } = null!;

        public int Qty { get; set; }

        public decimal Price { get; set; }

       
    }
}
