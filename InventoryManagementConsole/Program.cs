using InventoryManagementConsole;
using System.Globalization;

class Program
{
    private readonly Product? _productDto;
    static void Main()
    {
        int productId = 0;
        string productName;
        int productQuantity = 0;
        decimal productPrice = 0;

        InventoryManager inventory = new InventoryManager();
        while (true)
        {
            //Title
            Console.WriteLine("\nInventory Management");

            //Add Product
            Console.WriteLine("1. Add Product");

            //Remove Product
            Console.WriteLine("2. Remove Product");

            //Update Product
            Console.WriteLine("3. Update Product");

            //List of Products
            Console.WriteLine("4. List of Products");

            //Get Total Inventory Value
            Console.WriteLine("5. Total Inventory Value");

            //Exit
            Console.WriteLine("6. Exit");

            //Option
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                //ErrorMessage
                Console.WriteLine("Invalid Input, Please Enter a Number");
                continue;
            }

            switch (choice)
            {
                case 1: //Add Product
                    Console.Clear();

                    Console.Write("Enter Product Name: "); //Name
                    productName = Console.ReadLine();

                    while (true)
                    {
                        Console.Write("\nEnter Product Quantity: ");
                        if (int.TryParse(Console.ReadLine(), out productQuantity) && productQuantity >= 0)
                            break;
                        Console.WriteLine("Invalid input. Enter a valid non-negative integer for Quantity.");
                    }

                    while (true)
                    {
                        Console.Write("\nEnter Product Price: ");
                        if (decimal.TryParse(Console.ReadLine(), out productPrice) && productPrice >= 0)
                            break;
                        Console.WriteLine("Invalid input. Enter a valid non-negative decimal for Price.");
                    }

                    inventory.AddProduct(new Product(null, productName, productQuantity, productPrice));

                    break;
                case 2: //Remove Product
                    while (true)
                    {
                        Console.Write("\nEnter Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                            break;
                        Console.WriteLine("Invalid input. Enter a valid positive integer for Product ID.");
                    }

                    inventory.DeleteProduct(new Product(productId));

                    break;
                case 3: //Update Product
                    while (true)
                    {
                        Console.Write("\nEnter Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                            break;
                        Console.WriteLine("Invalid input. Enter a valid positive integer for Product ID.");
                    }

                    while (true)
                    {
                        Console.Write("\nEnter Product Quantity: ");
                        if (int.TryParse(Console.ReadLine(), out productQuantity) && productQuantity >= 0)
                            break;
                        Console.WriteLine("Invalid input. Enter a valid non-negative integer for Quantity.");
                    }

                    inventory.UpdateProduct(new Product(productId,null,productQuantity));
                    break;
                case 4: //List of Products
                    inventory.ListProducts();
                    break;
                case 5: //Total Inventory Value
                    Console.WriteLine($"Total Inventory Value: ");
                    inventory.GetTotalValue();
                    break;
                case 6:
                    return;
                default : //Invalid
                    Console.WriteLine("Invalid option Please Choose again");
                    break;

            }
        }
    }
}