using System;
namespace WebApp.Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {
        }

        public Guid OrderId { get; set; }
        public Product OrderedProduct { get; set; }
        public int Quantity { get; set; }
    }
}

