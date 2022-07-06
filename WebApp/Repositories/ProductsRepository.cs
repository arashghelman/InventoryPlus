using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class ProductsRepository
    {
        public async Task<IEnumerable<Product>> SelectAllAsync()
        {
            using var connection = SqliteConnectionHandler.Connect();

            var products = await connection.QueryAsync<Product>(
                @"SELECT * from products");
            return products;
        }

        public async Task<Product> SelectSingleAsync(Guid id)
        {
            using var connection = SqliteConnectionHandler.Connect();

            var product = await connection.QuerySingleOrDefaultAsync<Product>(
                @"SELECT * from products WHERE productId = @id",
                new { id = id.ToString() });
            return product;
        }

        public async Task InsertAsync(Product product)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"INSERT INTO products(productId, name, categoryId, stock, submissionDate, unit, price)
                VALUES(@productId, @name, @categoryId, @stock, date(), @unit, @price)",
                new
                {
                    productId = product.ProductId,
                    name = product.Name,
                    categoryId = product.CategoryId.ToString(),
                    stock = product.Stock,
                    unit = product.Unit,
                    price = product.Price
                }, commandType: System.Data.CommandType.Text);
        }

        public async Task UpdateAsync(Product product)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"UPDATE products SET name = @name, categoryId = @categoryId,
                stock = @stock, unit = @unit, price = @price WHERE productId = @productId",
                new
                {
                    name = product.Name,
                    categoryId = product.CategoryId.ToString(),
                    stock = product.Stock,
                    unit = product.Unit,
                    price = product.Price,
                    productId = product.ProductId
                }, commandType: System.Data.CommandType.Text);
        }

        // not working
        public async Task DeleteAsync(Guid id)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"DELETE FROM products WHERE productId = @id", new { id = id.ToString() },
                commandType: System.Data.CommandType.Text);
        }
    }
}