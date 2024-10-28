namespace dotnetAPI.Models.DTOs
{
    public class EditProductDTO
    {   
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
