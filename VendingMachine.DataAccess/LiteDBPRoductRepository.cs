using LiteDB;
using VendingMachine.Business.DataAccess;
using VendingMachine.Business.Models;

namespace RemoteLearning.VendingMachine.DataAccess
{
    internal class LiteDBProductRepository : IProductRepository
    {
        private readonly ILiteCollection<Product> collection;

        private readonly ICollection<Product> Products = new List<Product>() {
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

        public LiteDBProductRepository(string connectionString)
        {
            var database = new LiteDatabase(connectionString);
            collection = database.GetCollection<Product>();
        }

        public void Create(Product product)
        {
            collection.Insert(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return collection.FindAll();
        }

        public Product GetByColumnId(int columnId)
        {
            return collection.Find(product => product.ColumnId == columnId).FirstOrDefault();
        }

        public void Update(Product product)
        {
            collection.Update(product);
        }

        public void Delete(Product product)
        {
            collection.Delete(product.ColumnId);
        }
    }
}
