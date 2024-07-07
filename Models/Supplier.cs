namespace Backend_almog.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? SupplierImage { get; set; }
        public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}
