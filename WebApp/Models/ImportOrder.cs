using System;
namespace WebApp.Models
{
    public class ImportOrder : Order
    {
        public StoreBranch Source { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}

