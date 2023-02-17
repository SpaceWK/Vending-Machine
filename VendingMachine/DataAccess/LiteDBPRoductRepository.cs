using LiteDB;
using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.DataAccess
{
    internal class LiteDBPRoductRepository : IProductRepository
    {
        private readonly ILiteCollection<Product> collection;
        public LiteDBPRoductRepository(string connectionString)
        {
            var database = new LiteDatabase(connectionString);
            collection = database.GetCollection<Product>();
            //ICollection<Product> Products = new List<Product>() {
            //    new Product {
            //        ColumnId = 1,
            //        Name = "Chocolate",
            //        Price = 5,
            //        Quantity = 15
            //    },
            //    new Product {
            //        ColumnId = 2,
            //        Name = "Cola",
            //        Price = 7,
            //        Quantity = 12
            //    },
            //    new Product {
            //        ColumnId = 3,
            //        Name = "Water",
            //        Price = 9,
            //        Quantity = 10
            //    }
            //};
            //collection.Insert(Products);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return collection.FindAll();
        }

        public Product GetByColumnId(int columnId)
        {
            return collection.Find(product => product.ColumnId == columnId).FirstOrDefault();
        }
    }
}
