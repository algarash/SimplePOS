namespace SimplePOS.ViewModels
{
    public class InwardCreateViewModel
    {
        public int SupplierId { get; set; }
        public DateTime Date { get; set; }
        public List<InwardProductViewModel> Products { get; set; } = new List<InwardProductViewModel>();
    }

    public class InwardProductViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class InwardEditViewModel
    {
        public int InwardId { get; set; }
        public int SupplierId { get; set; }
        public DateTime Date { get; set; }
        public List<InwardProductViewModel> Products { get; set; } = new List<InwardProductViewModel>();
    }

 
}
