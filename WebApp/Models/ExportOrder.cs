using System;
namespace WebApp.Models
{
    public class ExportOrder : Order
    {
        public Guid DestinationId { get; set; }
        public DateTime ExportDate { get; set; }

        public static ExportOrder Create(Guid destinationId, DateTime exportDate, string description)
        {
            var export = new ExportOrder
            {
                OrderId = Guid.NewGuid(),
                State = OrderState.PENDING,
                Details = new(),
                DestinationId = destinationId,
                ExportDate = exportDate,
                Description = description
            };

            return export;
        }
    }
}

