namespace Backend_almog.DTO
{
    public class DeliveryItemDTO
    {
        public int DeliveryItemId { get; set; }
        public int DeliveryId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductDTO Product { get; set; }
    }
}
