using System;
namespace WebApp.Models
{
    public abstract class Order
    {
        public Guid OrderId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public OrderState State { get; set; }
        public List<OrderDetail> Details { get; set; }
        public string Description { get; set; }

        public void ChangeState(OrderState state)
        {
            if (State is not OrderState.PENDING) return;

            State = state;
        }
    }

    public enum OrderState
    {
        ACCEPTED, REJECTED, PENDING
    }
}

