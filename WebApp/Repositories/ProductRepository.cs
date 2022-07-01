using System;
using Dapper;
using Microsoft.Data.Sqlite;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class ProductRepository
    {

        public async Task<IEnumerable<Product>> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}

