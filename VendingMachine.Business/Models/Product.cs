using LiteDB;

namespace VendingMachine.Business.Models
{
    internal class Product
    {
        [BsonId]
        public int ColumnId { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

    }
}
