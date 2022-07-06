using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class OrdersRepository
    {
        public async Task UpdateAsync(Order order)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"UPDATE orders SET state = @state WHERE orderId = @orderId",
                new
                {
                    state = order.State.ToString(),
                    orderId = order.OrderId.ToString()
                }, commandType: System.Data.CommandType.Text);
        }
    }
}

