using DGP.DesignPatterns.Composite.Models;

namespace DGP.DesignPatterns.Composite
{
    class Client
    {
        public void Execute()
        {
            var apple = new Product("Apple", 3.5M);
            var kiwi = new Product("Kiwi", 1.23M);

            var order = new Order();

            order.AddProduct(apple, 2);
            order.AddProduct(kiwi, 6);

            var totalCost = order.TotalCost;
        }
    }
}
