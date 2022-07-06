using System;
namespace WebApp.Models
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}