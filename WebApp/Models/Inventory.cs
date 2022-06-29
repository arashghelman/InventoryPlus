using System;
namespace WebApp.Models
{
    public class Inventory
    {
        public Inventory()
        {
        }

        public List<InventoryPartition> Partitions { get; set; }
    }
}

