using System.ComponentModel.DataAnnotations;

namespace SwiggyApp.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
