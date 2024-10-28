using System;

namespace dotnetAPI.models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
