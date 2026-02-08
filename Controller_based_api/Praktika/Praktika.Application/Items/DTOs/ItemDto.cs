namespace Praktika.Application.Items.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Notes { get; set; }
        public string? ImageBase64 { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}