using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.DataAccess
{
    internal interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetByColumnId(int columnId);
    }
}
