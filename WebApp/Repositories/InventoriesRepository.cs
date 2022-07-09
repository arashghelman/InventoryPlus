using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class InventoriesRepository
    {
        public async Task<IEnumerable<Inventory>> SelectAllAsync()
        {
            using var connection = SqliteConnectionHandler.Connect();

            var inventories = await connection.QueryAsync<Inventory>(
                @"SELECT inventoryId, roomNumber, floorNumber, shelfNumber
                FROM inventories");

            foreach (var item in inventories)
            {
                var productIds = await connection.QueryAsync<Guid>(
                    @"SELECT productId FROM inventoryProducts WHERE inventoryId = @id",
                    new { id = item.InventoryId.ToString() });
                item.Products = productIds.ToList();
            }

            return inventories;
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

