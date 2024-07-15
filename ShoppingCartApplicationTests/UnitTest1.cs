using Smart_Cart_Application;

namespace ShoppingCartApplicationTests
{
    public class UnitTest1
    {

        [Fact]
        public void AddItem_ShouldAddProductToCart()
        {
            var cart = new ShoppingCart();
            var product = new Product("Apple", 0.99m, ProductCategory.Food);

            cart.AddItem(product);

            Assert.Equal(0.99m, cart.CalculateTotalCost());
        }

        [Fact]
        public void RemoveItem_ShouldRemoveProductFromCart()
        {
            var cart = new ShoppingCart();
            var product = new Product("Apple", 0.99m, ProductCategory.Food);

            cart.AddItem(product);
            cart.RemoveItem(product);

            Assert.Equal(0m, cart.CalculateTotalCost());
        }

        [Fact]
        public void CalculateTotalCost_ShouldReturnCorrectTotal()
        {
            var cart = new ShoppingCart();
            var product1 = new Product("Apple", 0.99m, ProductCategory.Food);
            var product2 = new Product("T-Shirt", 9.99m, ProductCategory.Clothing);

            cart.AddItem(product1);
            cart.AddItem(product2);

            Assert.Equal(10.98m, cart.CalculateTotalCost());
        }
    }

}
