using RemoteLearning.VendingMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase, IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            if (HasProducts(products))
                return;

            DisplayLine("The items in the shelf are:", ConsoleColor.Yellow);
            foreach (Product product in products)
                Console.WriteLine("{0} - {1} ({2}) {3} lei", product.ColumnId, product.Name, product.Quantity, product.Price);
        }

        private bool HasProducts(IEnumerable<Product> products)
        {
            if (products == null || products.Any() != true)
            {
                Display("Shelf is empty", ConsoleColor.Red);
                return true;
            }
            return false;
        }
    }
}
