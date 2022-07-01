using System;
namespace WebApp.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Stock { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Unit { get; set; }
        public float Price { get; set; }
    }
}

