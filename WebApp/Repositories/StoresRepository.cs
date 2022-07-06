using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class StoresRepository
    {
        public StoresRepository()
        {
        }

        public async Task<IEnumerable<Store>> SelectAllAsync()
        {
            using var connection = SqliteConnectionHandler.Connect();

            var stores = await connection.QueryAsync<Store>(
                @"SELECT storeId, address from stores");
            return stores;
        }

        public async Task<Store> SelectSingleAsync(Guid id)
        {
            using var connection = SqliteConnectionHandler.Connect();

            var store = await connection.QuerySingleOrDefaultAsync<Store>(
                @"SELECT storeId, address from stores WHERE storeId = @id",
                new { id = id.ToString() });
            return store;
        }
    }
}

