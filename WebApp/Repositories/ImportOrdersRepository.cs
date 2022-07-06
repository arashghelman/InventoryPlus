using System;
using Dapper;
using WebApp.Models;
using WebApp.Utilities;

namespace WebApp.Repositories
{
    public class ImportOrdersRepository
    {
        public async Task<IEnumerable<ImportOrder>> SelectAllAsync()
        {
            using var connection = SqliteConnectionHandler.Connect();

            var importsDict = new Dictionary<Guid, ImportOrder>();

            var imports = await connection.QueryAsync<ImportOrder, OrderDetail, ImportOrder>(
                @"SELECT o.orderId, o.state, o.description, o.submissionDate,
                i.sourceId, i.arrivalDate, od.orderId, od.productId, od.quantity
                FROM orders o JOIN importOrders i ON o.orderId = i.orderId
                LEFT JOIN orderDetails od ON i.orderId = od.orderId",
                (import, orderDetail) =>
                {
                    if (!importsDict.TryGetValue(import.OrderId, out ImportOrder importEntry))
                    {
                        importEntry = import;
                        importEntry.Details = new();
                        importsDict.Add(importEntry.OrderId, importEntry);
                    }

                    importEntry.Details.Add(orderDetail);
                    return importEntry;
                }, splitOn: "orderId");
            return imports.Distinct().ToList();
        }

        public async Task<ImportOrder> SelectSingleAsync(Guid id)
        {
            var imports = await SelectAllAsync();

            return imports.SingleOrDefault(im => im.OrderId == id);
        }

        public async Task InsertAsync(ImportOrder import)
        {
            using var connection = SqliteConnectionHandler.Connect();

            await connection.ExecuteAsync(
                @"INSERT INTO orders(orderId, state, description, submissionDate)
                VALUES(@orderId, @state, @description, date());
                INSERT INTO importOrders(orderId, sourceId, arrivalDate)
                VALUES(@orderId, @sourceId, @arrivalDate);",
                new
                {
                    orderId = import.OrderId.ToString(),
                    state = import.State.ToString(),
                    description = import.Description,
                    sourceId = import.SourceId.ToString(),
                    arrivalDate = import.ArrivalDate
                }, commandType: System.Data.CommandType.Text);
        }
    }
}

