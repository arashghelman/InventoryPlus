using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class CategoriesRepository
    {
        public async Task<IEnumerable<Category>> SelectAllAsync()
        {
            using var connection = SqliteConnectionHandler.Connect();

            var categories = await connection.QueryAsync<Category>(
                @"SELECT categoryId, name from categories");
            return categories;
        }

        public async Task<Category> SelectSingleAsync(Guid id)
        {
            using var connection = SqliteConnectionHandler.Connect();

            var category = await connection.QuerySingleOrDefaultAsync<Category>(
                    @"SELECT categoryId, name from categories
                    WHERE categoryId = @id", new { id = id.ToString() });
            return category;
        }
    }
}