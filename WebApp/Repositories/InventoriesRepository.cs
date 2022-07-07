using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class InventoriesRepository
    {
        // not working
        public async Task<IEnumerable<Inventory>> SelectAllAsync()
        {
            using var connection = SqliteConnectionHandler.Connect();

            var inventoriesDict = new Dictionary<Guid, Inventory>();

            var inventories = await connection.QueryAsync<Inventory, Guid, Inventory>(
                @"SELECT i.inventoryId, i.roomNumber, i.floorNumber, i.shelfNumber,
                ip.productId FROM inventories i LEFT JOIN inventoryProducts ip
                ON i.inventoryId = ip.inventoryId",
                (inventory, productId) =>
                {
                    if (!inventoriesDict.TryGetValue(inventory.InventoryId, out var inventoryEntry))
                    {
                        inventoryEntry = inventory;
                        inventoryEntry.Products = new();
                        inventoriesDict.Add(inventoryEntry.InventoryId, inventoryEntry);
                    }

                    inventoryEntry.Products.Add(productId);
                    return inventory;
                },
                splitOn: "productId");
            return inventories.Distinct().ToList();
        }

        public async Task InsertAsync(Inventory inventory)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"INSERT INTO inventories(inventoryId, roomNumber, floorNumber, shelfNumber)
                VALUES(@inventoryId, @roomNumber, @floorNumber, @shelfNumber)",
                new
                {
                    inventoryId = inventory.InventoryId,
                    roomNumber = inventory.RoomNumber,
                    floorNumber = inventory.FloorNumber,
                    shelfNumber = inventory.ShelfNumber
                }, commandType: System.Data.CommandType.Text);
        }

        public async Task InsertProductAsync(Guid inventoryId, Guid productId)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"INSERT INTO inventoryProducts(inventoryId, productId)
                VALUES(@inventoryId, @productId)",
                new
                {
                    inventoryId = inventoryId.ToString(),
                    productId = productId.ToString()
                }, commandType: System.Data.CommandType.Text);
        }
    }
}

