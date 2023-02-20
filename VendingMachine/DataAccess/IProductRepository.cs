using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.DataAccess
{
    internal interface IProductRepository
    {
        void CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetByColumnId(int columnId);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
