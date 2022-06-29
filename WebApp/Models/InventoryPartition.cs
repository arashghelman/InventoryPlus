using System;
namespace WebApp.Models
{
    public class InventoryPartition
    {
        public InventoryPartition()
        {
        }

        public string RoomNumber { get; set; }
        public string FloorNumber { get; set; }
        public string ShelfNumber { get; set; }
        public List<Product> Products { get; set; }
    }
}

