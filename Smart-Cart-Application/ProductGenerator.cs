using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_Application
{
    public class ProductGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly Dictionary<ProductCategory, (string[], decimal[])> _categoryData = new Dictionary<ProductCategory, (string[], decimal[])>
        {
            { ProductCategory.Food, (new[] { "Apple", "Bread", "Milk", "Cheese", "Eggs" }, new[] { 1.99m, 2.49m, 3.49m, 4.99m, 5.99m }) },
            { ProductCategory.Clothing, (new[] { "T-Shirt", "Jeans", "Jacket", "Hat", "Scarf" }, new[] { 19.99m, 49.99m, 99.99m, 14.99m, 9.99m }) },
            { ProductCategory.Electronics, (new[] { "Laptop", "Smartphone", "Headphones", "Monitor", "Keyboard" }, new[] { 999.99m, 699.99m, 199.99m, 299.99m, 150.00m }) }
        };

        public List<Product> GenerateProducts(ProductCategory category, int count)
        {
            var (names, prices) = _categoryData[category];
            var products = new HashSet<Product>();
            var usedNames = new HashSet<string>();

            while (products.Count < count && usedNames.Count < names.Length)
            {
                var name = names[_random.Next(names.Length)];
                if (!usedNames.Contains(name))
                {
                    var price = prices[_random.Next(prices.Length)];
                    var product = new Product(name, price, category);
                    products.Add(product);
                    usedNames.Add(name);
                }
            }

            return products.ToList();
        }


    }
}
