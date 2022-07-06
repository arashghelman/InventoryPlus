using System;
namespace WebApp.Models
{
    public class ImportOrder : Order
    {
        public Guid SourceId { get; set; }
        public DateTime ArrivalDate { get; set; }

        public static ImportOrder Create(Guid sourceId, DateTime arrivalDate, string description)
        {
            var import = new ImportOrder
            {
                OrderId = Guid.NewGuid(),
                State = OrderState.PENDING,
                Details = new(),
                SourceId = sourceId,
                ArrivalDate = arrivalDate,
                Description = description
            };

            return import;
        }
    }
}

