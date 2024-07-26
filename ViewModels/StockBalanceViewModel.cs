namespace SimplePOS.ViewModels
{
    public class StockBalanceViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Inwards { get; set; }
        public int Outwards { get; set; }
        public int InHand { get; set; }
    }
}
