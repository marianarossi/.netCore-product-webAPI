namespace dotnetAPI.Models.DTOs
{
    public class CreateProductDTO
    {

        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
