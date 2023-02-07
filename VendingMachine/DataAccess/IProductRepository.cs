using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.DataAccess
{
    internal interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetByColumnId(int columnId);
    }
}
