using System;
namespace WebApp.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Stock { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Unit { get; set; }
        public float Price { get; set; }

        public static Product Create(string name, Guid categoryId, int stock, string unit, float price)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = name,
                CategoryId = categoryId,
                Stock = stock,
                Unit = unit,
                Price = price
            };

            return product;
        }
    }
}