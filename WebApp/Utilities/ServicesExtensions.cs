using System;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Utilities
{
    public static class ServicesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(ProductsRepository));
            services.AddScoped(typeof(CategoriesRepository));
            services.AddScoped(typeof(InventoriesRepository));
            services.AddScoped(typeof(StoresRepository));
            services.AddScoped(typeof(ExportOrdersRepository));
            services.AddScoped(typeof(ImportOrdersRepository));
            services.AddScoped(typeof(OrderDetailsRepository));
            services.AddScoped(typeof(OrdersRepository));
        }
    }
}

