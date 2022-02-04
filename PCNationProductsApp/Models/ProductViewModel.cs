namespace PCNationProductsApp.Models
{
    public class ProductViewModel
    {       
        public long ProductId { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }
        public int Quantity { get; set; }        
       
    }
}
