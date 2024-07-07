namespace Backend_almog.DTO
{
    public class DeliveryDTO
    {
        public int DeliveryId { get; set; }
        public int SupplierId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public SupplierDTO Supplier { get; set; }
        public List<DeliveryItemDTO> DeliveryItems { get; set; }
    }
}
