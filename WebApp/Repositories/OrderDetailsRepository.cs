using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class OrderDetailsRepository
    {
        public async Task InsertAsync(OrderDetail orderDetail)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"INSERT INTO orderDetails(orderId, productId, quantity)
                VALUES(@orderId, @productId, @quantity)",
                new
                {
                    orderId = orderDetail.OrderId.ToString(),
                    productId = orderDetail.ProductId.ToString(),
                    quantity = orderDetail.Quantity
                }, commandType: System.Data.CommandType.Text);
        }
    }
}

