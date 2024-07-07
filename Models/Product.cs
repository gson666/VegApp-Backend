using System.ComponentModel;

namespace Backend_almog.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public decimal Price { get; set; }   
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<DeliveryItem> DeliveryItems { get; set; } = new List<DeliveryItem>();
    }
}
