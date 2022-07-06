using System;
namespace WebApp.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public static Category Create(string name)
        {
            var category = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = name
            };

            return category;
        }
    }
}

