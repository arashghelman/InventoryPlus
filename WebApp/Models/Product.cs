using System;
namespace WebApp.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Stock { get; set; }
        public DateTime SubmissionDate { get; set; }
        public List<string> PhotosUrl { get; set; }
        public string Unit { get; set; }
        public float PricePerUnit { get; set; }
    }
}

