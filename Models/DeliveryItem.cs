namespace Backend_almog.Models
{
    public class DeliveryItem
    {
        public int DeliveryItemId { get; set; }
        public int DeliveryId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Delivery Delivery { get; set; }
        public Product Product { get; set; } 
    }
}
