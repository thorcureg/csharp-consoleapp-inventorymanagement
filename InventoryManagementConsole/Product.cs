using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementConsole
{
    public class Product
    {
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public int? QuantityInStock { get; set; }
        public decimal? Price { get; set; }

        public Product(int? productId = null, string? name = null, int? quantity = null, decimal? price = null)
        {
            if (productId <= 0)
                throw new ArgumentException("Product ID must be a positive integer.");

            ProductId = productId;
            Name = name;
            QuantityInStock = quantity;
            Price = price;
        }
    }

}
