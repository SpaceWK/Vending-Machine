using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.DataAccess
{
    internal class ProductRepository : IProductRepository
    {
        private static readonly ICollection<Product> Products = new List<Product>() {
            new Product {
                ColumnId = 1,
                Name = "Chocolate",
                Price = 5,
                Quantity = 15
            },
            new Product {
                ColumnId = 2,
                Name = "Cola",
                Price = 7,
                Quantity = 12
            },
            new Product {
                ColumnId = 3,
                Name = "Water",
                Price = 9,
                Quantity = 10
            }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }

        public Product GetByColumnId(int columnId)
        {
            foreach (Product product in GetAllProducts())
            {
                if (columnId == product.ColumnId)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
