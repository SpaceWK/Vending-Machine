using VendingMachine.Business.DataAccess;
using VendingMachine.Business.Models;

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

        public void Create(Product product)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return Products;
        }

        public Product GetByColumnId(int columnId)
        {
            foreach (Product product in GetAll())
            {
                if (columnId == product.ColumnId)
                {
                    return product;
                }
            }
            return null;
        }

        public void Update(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
