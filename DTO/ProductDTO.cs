namespace Backend_almog.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
