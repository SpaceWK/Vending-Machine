using VendingMachine.Business.Models;

namespace VendingMachine.Business.PresentationLayer
{
    internal interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);
    }
}