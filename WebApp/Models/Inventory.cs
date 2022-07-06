using System;
namespace WebApp.Models
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public string RoomNumber { get; set; }
        public string FloorNumber { get; set; }
        public string ShelfNumber { get; set; }
        public List<Guid> Products { get; set; }

        public static Inventory Create(string roomNumber, string floorNumber, string shelfNumber)
        {
            var inventory = new Inventory
            {
                InventoryId = Guid.NewGuid(),
                RoomNumber = roomNumber,
                FloorNumber = floorNumber,
                ShelfNumber = shelfNumber,
                Products = new()
            };

            return inventory;
        }
    }
}

