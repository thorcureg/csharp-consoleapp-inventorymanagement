using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace InventoryManagementConsole
{
    class InventoryManager
    {
        private readonly List<Product> _products = new List<Product>();
        private int nextProductId = 1; 

        //Add Product to the List
        public void AddProduct(Product product)
        {
            product.ProductId = nextProductId;

            _products.Add(product);

            nextProductId++;
            Console.Clear();
            Console.WriteLine("\nProduct added successfully.");
        }
        //Get the List of Products
        public void ListProducts()
        {
            if (_products.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Inventory is empty.");
                return;
            }
            Console.Clear();
            Console.WriteLine("\nCurrent Inventory:");
            foreach (var product in _products)
            {
                Console.WriteLine($"\nID: {product.ProductId} " +
                    $"\nName: {product.Name} " +
                    $"\nQuantity: {product.QuantityInStock} " +
                    $"\nPrice: {product.Price}"
                    );
            }
        }

        //Update the Product if ID is Existing
        public void UpdateProduct(Product product)
        {
            if (_products.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Inventory is empty.");
                return;
            }

            if (product == null || product.ProductId <= 0)
            {
                Console.WriteLine("\nError: Invalid product details.");
                return;
            }

            var productToUpdate = _products.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (productToUpdate == null)
            {
                Console.WriteLine("\nError: Product not found.");
                return;
            }

            if (product.QuantityInStock == null || product.QuantityInStock < 0)
            {
                Console.WriteLine("\nError: Quantity cannot be negative or null.");
                return;
            }

            productToUpdate.QuantityInStock = product.QuantityInStock;

            Console.Clear();
            Console.WriteLine("\nProduct quantity updated successfully.");
        }

        //Delete Product from List
        public void DeleteProduct(Product product)
        {
            var productToRemove = _products.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
                Console.Clear();
                Console.WriteLine("\nProduct deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nError: Product not found.");
            }
        }

        //Total Value from List
        public void GetTotalValue()
        {
            decimal totalValue = _products.Sum(p => (p.QuantityInStock ?? 0) * (p.Price ?? 0));

            Console.Clear();
            Console.WriteLine($"\nTotal Inventory Value: {totalValue}");
        }
    }
}
