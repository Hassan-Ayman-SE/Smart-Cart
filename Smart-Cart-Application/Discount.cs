using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_Application
{

    public abstract class Discount
    {
        public abstract decimal CalculateDiscount(List<Product> items);
    }

    public class PercentageDiscount : Discount
    {
        private ProductCategory _category;
        private decimal _percentage;

        public PercentageDiscount(ProductCategory category, decimal percentage)
        {
            _category = category;
            _percentage = percentage;
        }

        public override decimal CalculateDiscount(List<Product> items)
        {
            decimal discount = 0;
            foreach (var item in items)
            {
                if (item.Category == _category)
                {
                    discount += item.Price * _percentage / 100;
                }
            }
            return discount;
        }
    }

    public class BuyOneGetOneFree : Discount
    {
        private string _productName;

        public BuyOneGetOneFree(string productName)
        {
            _productName = productName;
        }

        public override decimal CalculateDiscount(List<Product> items)
        {
            int count = 0;
            decimal price = 0;

            foreach (var item in items)
            {
                if (item.Name.Equals(_productName, System.StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                    price = item.Price;
                }
            }

            int freeItems = count / 2;
            return freeItems * price;
        }
    }

}
