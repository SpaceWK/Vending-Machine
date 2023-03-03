using VendingMachine.Business.Models;

namespace VendingMachine.Business.DataAccess
{
    internal interface IProductRepository
    {
        void Create(Product product);
        IEnumerable<Product> GetAll();
        Product GetByColumnId(int columnId);
        void Update(Product product);
        void Delete(Product product);
    }
}
