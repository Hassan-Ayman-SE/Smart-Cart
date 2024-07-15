using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_Application
{
    public class ShoppingCart
    {
        private List<Product> _items;
        private List<Discount> _discounts;

        public ShoppingCart()
        {
            _items = new List<Product>();
            _discounts = new List<Discount>();
        }

        public void AddItem(Product product)
        {
            _items.Add(product);
            Console.WriteLine($"{product.Name} has been added to the cart.");
        }

        public void RemoveItem(Product product)
        {
            if (_items.Contains(product))
            {
                _items.Remove(product);
                Console.WriteLine($"{product.Name} has been removed from the cart.");
            }
            else
            {
                Console.WriteLine($"{product.Name} is not in the cart.");
            }
        }

        public void ViewItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Your shopping cart is empty.");
                return;
            }

            Console.WriteLine("Items in your cart:");
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }

        public decimal CalculateTotalCost()
        {
            decimal total = _items.Sum(item => item.Price);

            foreach (var discount in _discounts)
            {
                total -= discount.CalculateDiscount(_items);
            }

            return total;
        }

        public void AddDiscount(Discount discount)
        {
            _discounts.Add(discount);
            Console.WriteLine("Discount added.");
        }
    }
}

