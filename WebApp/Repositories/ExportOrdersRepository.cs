using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class ExportOrdersRepository
    {
        public async Task<IEnumerable<ExportOrder>> SelectAllAsync()
        {
            using var connection = SqliteConnectionHandler.Connect();

            var exportsDict = new Dictionary<Guid, ExportOrder>();

            var exports = await connection.QueryAsync<ExportOrder, OrderDetail, ExportOrder>(
                @"SELECT o.orderId, o.state, o.description, o.submissionDate,
                e.destinationId, e.exportDate, od.orderId, od.productId, od.quantity
                FROM orders o JOIN exportOrders e ON o.orderId = e.orderId
                LEFT JOIN orderDetails od ON e.orderId = od.orderId",
                (export, orderDetail) =>
                {
                    if(!exportsDict.TryGetValue(export.OrderId, out var exportEntry))
                    {
                        exportEntry = export;
                        exportEntry.Details = new();
                        exportsDict.Add(exportEntry.OrderId, exportEntry);
                    }

                    exportEntry.Details.Add(orderDetail);
                    return exportEntry;
                }, splitOn: "orderId");
            return exports.Distinct().ToList();
        }

        public async Task<ExportOrder> SelectSingleAsync(Guid id)
        {
            var exports = await SelectAllAsync();

            return exports.SingleOrDefault(ex => ex.OrderId == id);
        }

        public async Task InsertAsync(ExportOrder export)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"INSERT INTO orders(orderId, state, description, submissionDate)
                VALUES(@orderId, @state, @description, date());
                INSERT INTO exportOrders(orderId, destinationId, exportDate)
                VALUES(@orderId, @destinationId, @exportDate);",
                new
                {
                    orderId = export.OrderId.ToString(),
                    state = export.State.ToString(),
                    description = export.Description,
                    destinationId = export.DestinationId.ToString(),
                    exportDate = export.ExportDate
                }, commandType: System.Data.CommandType.Text);
        }
    }
}