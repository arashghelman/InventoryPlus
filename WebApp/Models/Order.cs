using System;
namespace WebApp.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public OrderState State { get; set; }
        public List<OrderDetail> Details { get; set; }
        public string Description { get; set; }
    }

    public enum OrderState
    {
        APPROVED, REJECTED, PENDING
    }
}

