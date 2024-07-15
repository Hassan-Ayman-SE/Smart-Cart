using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_Application
{
    public enum ProductCategory
    {
        Food,
        Clothing,
        Electronics
    }

    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public ProductCategory Category { get; }

        public Product(string name, decimal price, ProductCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - ${Price:F2}";
        }
    }
}
