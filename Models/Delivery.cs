namespace Backend_almog.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int SupplierId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<DeliveryItem> DeliveryItems { get; set; } = new List<DeliveryItem>();
    }
}
