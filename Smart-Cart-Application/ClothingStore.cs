using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_Application
{
    public class ClothingStore
    {
        private List<Product> _products;

        public ClothingStore(ProductGenerator generator, int productCount)
        {
            _products = new List<Product>();
            for (int i = 0; i < productCount; i++)
            {
                _products = generator.GenerateProducts(ProductCategory.Clothing, productCount);
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Available Clothing Store Products:");
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }

        public Product GetProductByName(string name)
        {
            return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
