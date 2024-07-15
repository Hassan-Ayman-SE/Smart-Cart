namespace Smart_Cart_Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productGenerator = new ProductGenerator();
            var groceryStore = new GroceryStore(productGenerator, 8);
            var clothingStore = new ClothingStore(productGenerator, 8);
            var shoppingCart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("\nWelcome to the Smart Shopping Cart Application!");
                Console.WriteLine("1. Shop at Grocery Store");
                Console.WriteLine("2. Shop at Clothing Store");
                Console.WriteLine("3. View Shopping Cart");
                Console.WriteLine("4. Calculate Total Cost");
                Console.WriteLine("5. Add Discount");
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option: ");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShopAtStore(groceryStore, shoppingCart);
                        break;
                    case "2":
                        ShopAtStore(clothingStore, shoppingCart);
                        break;
                    case "3":
                        shoppingCart.ViewItems();
                        break;
                    case "4":
                        Console.WriteLine($"Total cost: ${shoppingCart.CalculateTotalCost()}");
                        break;
                    case "5":
                        AddDiscount(shoppingCart);
                        break;
                    case "6":
                        Console.WriteLine("Thank you for shopping with us!");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void ShopAtStore(dynamic store, ShoppingCart cart)
        {
            store.DisplayProducts();
            Console.Write("Enter the name of the product to add to the cart (or type 'back' to return): ");
            var productName = Console.ReadLine();

            if (productName.Equals("back", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var product = store.GetProductByName(productName);
            if (product != null)
            {
                cart.AddItem(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void AddDiscount(ShoppingCart cart)
        {
            Console.WriteLine("Select Discount Type:");
            Console.WriteLine("1. Percentage Discount on Category");
            Console.WriteLine("2. Buy One Get One Free");
            var discountOption = Console.ReadLine();

            switch (discountOption)
            {
                case "1":
                    Console.WriteLine("Enter Product Category (Food, Clothing, Electronics):");
                    var categoryStr = Console.ReadLine();
                    if (Enum.TryParse(categoryStr, out ProductCategory category))
                    {
                        Console.WriteLine("Enter Discount Percentage:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal percentage))
                        {
                            var discount = new PercentageDiscount(category, percentage);
                            cart.AddDiscount(discount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid percentage.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid category.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter Product Name for Buy One Get One Free:");
                    var productName = Console.ReadLine();
                    var bogoDiscount = new BuyOneGetOneFree(productName);
                    cart.AddDiscount(bogoDiscount);
                    break;
                default:
                    Console.WriteLine("Invalid discount type.");
                    break;
            }
        }
    }
}

